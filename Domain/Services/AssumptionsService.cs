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
            var assumpEntity = _assumpRepository.Find(assump => assump.Description == assumpRequest.Description)
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
            var assumpEntity = _assumpRepository.Find(assump => assump.Id.ToString() == assumpId)
                .FirstOrDefault();
            _ = assumpEntity ?? throw new NotFoundException<Assumption>("Assumption with id was not found.");

            _assumpRepository.SoftDelete(Guid.Parse(assumpId));
            _uow.Save();
        }
    }
}
