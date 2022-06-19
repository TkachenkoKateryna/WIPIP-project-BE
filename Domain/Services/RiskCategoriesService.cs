using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Models.Exceptions;

namespace Domain.Services
{
    public class RiskCategoriesService : IRiskCategoriesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<RiskCategory> _riskCategoryRepository;

        public RiskCategoriesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _riskCategoryRepository = _uow.GetRepository<RiskCategory>();
            _mapper = mapper;
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
            var riskCategoryEntity = _riskCategoryRepository.Find(rc => rc.Id == rcId).FirstOrDefault();

            _ = riskCategoryEntity ?? throw new NotFoundException("Risk category was not found");

            _riskCategoryRepository.SoftDelete(rcId);
            _uow.Save();
        }
    }
}
