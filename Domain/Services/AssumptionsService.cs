using Domain.Models.Exceptions;
using AutoMapper;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class AssumptionsService : IAssumptionsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Assumption> _assumpRepository;

        public AssumptionsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _assumpRepository = _uow.GetRepository<Assumption>();
            _mapper = mapper;
        }

        public AssumptionResponse AddAssumption(AssumptionRequest assumpRequest)
        {
            var assumpEntity = _assumpRepository.Find(a => a.Description == assumpRequest.Description && a.ProjectId == assumpRequest.ProjectId)
                .FirstOrDefault();

            if (assumpEntity != null)
            {
                throw new AlreadyExistsException("Assumption with such description already exists", "description");
            }

            assumpEntity = _mapper.Map<Assumption>(assumpRequest);
            var id = _assumpRepository.CreateWithVal(assumpEntity);
            _uow.Save();

            return GetAssumptionResponse(id);
        }

        public AssumptionResponse UpdateAssumption(AssumptionRequest assumpRequest, Guid assumpId)
        {
            var assumpEntity = _assumpRepository.Find(entity => entity.Id == assumpId).FirstOrDefault();
            _ = assumpEntity ?? throw new NotFoundException("Assumption was not found");

            if (_assumpRepository.Find(a => a.Description == assumpRequest.Description && a.ProjectId == assumpRequest.ProjectId && a.Id != assumpId).Any())
            {
                throw new AlreadyExistsException("Assumption with such description already exists", "description");
            }

            assumpEntity = _mapper.Map<Assumption>(assumpRequest);
            assumpEntity.Id = assumpId;
            _assumpRepository.Update(assumpEntity);
            _uow.Save();

            return GetAssumptionResponse(assumpId);
        }

        public void DeleteAssumption(Guid assumpId)
        {
            var assumpEntity = _assumpRepository.Find(entity => entity.Id == assumpId).FirstOrDefault();

            _ = assumpEntity ?? throw new NotFoundException("Assumption was not found.");

            _assumpRepository.SoftDelete(assumpId);
            _uow.Save();
        }

        private AssumptionResponse GetAssumptionResponse(Guid assumptionId)
        {
            return _mapper.Map<AssumptionResponse>(_assumpRepository.Find(entity => entity.Id == assumptionId)
                .FirstOrDefault());
        }
    }
}
