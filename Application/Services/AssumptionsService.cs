using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
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

        public IEnumerable<AssumptionResponse> GetAllAssumptionsByProject(string projectId)
        {
            return _assumpRepository.Find(o => o.ProjectId == Guid.Parse(projectId))
                .Select(entity => _mapper.Map<AssumptionResponse>(entity))
                .ToList();
        }

        public IEnumerable<AssumptionResponse> GetAllAssumptions()
        {
            return _assumpRepository.GetAllWithDeleted()
                .Select(entity => _mapper.Map<AssumptionResponse>(entity))
                .ToList();
        }

        public AssumptionResponse AddAssumption(AssumptionRequest assumpRequest)
        {
            var assumpEntity = _assumpRepository.FindWithDeleted(assump => assump.Description == assumpRequest.Description)
                .FirstOrDefault();

            if (assumpEntity != null)
            {
                throw new AlreadyExistsException<Assumption>("Assumption with such description already exists.");
            }

            assumpEntity = _mapper.Map<Assumption>(assumpRequest);

            _assumpRepository.Create(assumpEntity);

            _uow.Save();

            return _mapper.Map<AssumptionResponse>(_assumpRepository.Find(assump => assump.Id == assumpEntity.Id).FirstOrDefault());
        }

        public AssumptionResponse UpdateAssumption(AssumptionRequest assumpRequest, string assumpId)
        {
            var assumpEntity = _assumpRepository.Find(assump => assump.Id.ToString() == assumpId)
                 .FirstOrDefault();
            _ = assumpEntity ?? throw new NotFoundException<Objective>("Assumption with id was not found.");

            assumpEntity = _mapper.Map<Assumption>(assumpRequest);
            assumpEntity.Id = Guid.Parse(assumpId);
            _assumpRepository.Update(assumpEntity);
            _uow.Save();


            return _mapper.Map<AssumptionResponse>(_assumpRepository.Find(assump => assump.Id.ToString() == assumpId).FirstOrDefault());
        }

        public void DeleteAssumption(string assumpId)
        {
            var assumpEntity = _assumpRepository.FindWithDeleted(assump => assump.Id.ToString() == assumpId)
                .FirstOrDefault();
            _ = assumpEntity ?? throw new NotFoundException<Objective>("Assumption with id was not found.");

            _assumpRepository.SoftDelete(Guid.Parse(assumpId));
            _uow.Save();
        }
    }
}
