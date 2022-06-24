using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Services
{
    public class RiskCategoriesService : IRiskCategoriesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<RiskCategory> _riskCategoryRepository;
        private readonly Func<IQueryable<RiskCategory>, IIncludableQueryable<RiskCategory, object>> _includes;

        public RiskCategoriesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _riskCategoryRepository = _uow.GetRepository<RiskCategory>();
            _mapper = mapper;
            _includes = risk => risk
               .Include(s => s.Risks);
        }

        public IEnumerable<RiskCategoryResponse> GetRiskCategories()
        {
            return _riskCategoryRepository.GetAll().Select(rc => _mapper.Map<RiskCategoryResponse>(rc))
                .ToList();
        }

        public RiskCategoryResponse AddRiskCategory(RiskCategoryRequest rcRequest)
        {

            var rcEntity = _riskCategoryRepository.Find(rc => rc.Title == rcRequest.Title).FirstOrDefault();

            if (rcEntity != null)
            {
                throw new AlreadyExistsException("Risk category with such title already exists", "title");
            }

            rcEntity = _mapper.Map<RiskCategory>(rcRequest);

            var rcId = _riskCategoryRepository.CreateWithVal(rcEntity);
            _uow.Save();

            return _mapper.Map<RiskCategoryResponse>(_riskCategoryRepository.Find(rc => rc.Id == rcId)
                .FirstOrDefault());
        }

        public RiskCategoryResponse UpdateRiskCategory(RiskCategoryRequest rcRequest, Guid rcId)
        {
            var rcEntity = _riskCategoryRepository.Find(rc => rc.Id == rcId).FirstOrDefault();

            _ = rcEntity ?? throw new NotFoundException("Risk category was not found");

            rcEntity = _mapper.Map<RiskCategory>(rcRequest);

            rcEntity.Id = rcId;
            _riskCategoryRepository.Update(rcEntity);
            _uow.Save();

            return _mapper.Map<RiskCategoryResponse>(_riskCategoryRepository.Find(rc => rc.Id == rcId)
                .FirstOrDefault());
        }

        public void DeleteRiskCategory(Guid rcId)
        {
            var riskCategoryEntity = _riskCategoryRepository.Find(rc => rc.Id == rcId, _includes).FirstOrDefault();

            _ = riskCategoryEntity ?? throw new NotFoundException("Risk category was not found");

            if (riskCategoryEntity.Risks.Count != 0)
            {
                throw new AlreadyExistsException("Risk category has been already assigned to some risks. To delete the risk carwgory reassign it from risks.");
            }

            _riskCategoryRepository.SoftDelete(rcId);
            _uow.Save();
        }
    }
}
