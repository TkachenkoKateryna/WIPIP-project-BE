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
            return _riskCategoryRepository.GetAll()
                .Select(r => _mapper.Map<RiskCategoryResponse>(r))
                .ToList();
        }

        public RiskCategoryResponse AddRiskCategory(RiskCategoryRequest riskCategoryRequest)
        {

            var riskCategortEntity = _riskCategoryRepository
                .Find(riskCategory => riskCategory.Title == riskCategoryRequest.Title)
                .FirstOrDefault();

            if (riskCategortEntity != null)
            {
                throw new AlreadyExistsException<RiskCategory>("Assumption with such description already exists.");
            }

            riskCategortEntity = _mapper.Map<RiskCategory>(riskCategoryRequest);

            var id = _riskCategoryRepository.CreateWithVal(riskCategortEntity);
            _uow.Save();

            return _mapper.Map<RiskCategoryResponse>(_riskCategoryRepository.Find(skill => skill.Id == id).FirstOrDefault());
        }

        public RiskCategoryResponse UpdateRiskCategory(RiskCategoryRequest skillRequest, Guid riskCategoryId)
        {
            var riskCategortEntity = _riskCategoryRepository.Find(riskCategory => riskCategory.Id == riskCategoryId)
                .FirstOrDefault();
            _ = riskCategortEntity ?? throw new NotFoundException<Skill>("Assumption with id was not found.");

            riskCategortEntity = _mapper.Map<RiskCategory>(skillRequest);
            riskCategortEntity.Id = riskCategoryId;

            _riskCategoryRepository.Update(riskCategortEntity);
            _uow.Save();


            return _mapper.Map<RiskCategoryResponse>(_riskCategoryRepository.Find(riskCategory => riskCategory.Id == riskCategoryId).FirstOrDefault());
        }

        public void DeleteRiskCategory(Guid riskCategoryId)
        {
            var riskCategoryEntity = _riskCategoryRepository.Find(riskCategory => riskCategory.Id == riskCategoryId)
                .FirstOrDefault();
            _ = riskCategoryEntity ?? throw new NotFoundException<RiskCategory>("Assumption with id was not found.");

            _riskCategoryRepository.SoftDelete(riskCategoryId);
            _uow.Save();
        }
    }
}
