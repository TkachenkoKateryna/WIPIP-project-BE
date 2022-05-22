using Domain.Exceptions;
using AutoMapper;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ObjectiveService : IObjectiveService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Objective> _objectiveRepository;

        public ObjectiveService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _objectiveRepository = _uow.GetRepository<Objective>();
            _mapper = mapper;
        }

        public IEnumerable<ObjectiveResponse> GetAllObjectives()
        {
            return _objectiveRepository.GetAllWithDeleted()
                .Select(empEntity => _mapper.Map<ObjectiveResponse>(empEntity))
                .ToList();
        }

        public ObjectiveResponse AddObjective(ObjectiveRequest objDto)
        {
            var objEntity = _objectiveRepository.FindWithDeleted(ob => ob.Title == objDto.Title)
                .FirstOrDefault();

            if (objEntity != null)
            {
                throw new AlreadyExistsException<Objective>("Objective with such title already exists.");
            }

            objEntity = _mapper.Map<Objective>(objDto);

            _objectiveRepository.Create(objEntity);

            _uow.Save();

            return _mapper.Map<ObjectiveResponse>(_objectiveRepository.Find(ob => ob.Id == objEntity.Id).FirstOrDefault());
        }

        public ObjectiveResponse UpdateObjective(ObjectiveRequest objDto, string objId)
        {
            var objEntity = _objectiveRepository.Find(ob => ob.Id.ToString() == objId)
                 .FirstOrDefault();
            _ = objEntity ?? throw new NotFoundException<Objective>("Objective with id was not found.");

            objEntity = _mapper.Map<Objective>(objDto);
            objEntity.Id = Guid.Parse(objId);
            _objectiveRepository.Update(objEntity);
            _uow.Save();


            return _mapper.Map<ObjectiveResponse>(_objectiveRepository.Find(ob => ob.Id.ToString() == objId).FirstOrDefault());
        }

        public void DeleteObjective(string objId)
        {
            var objEntity = _objectiveRepository.FindWithDeleted(obj => obj.Id.ToString() == objId)
                .FirstOrDefault();
            _ = objEntity ?? throw new NotFoundException<Objective>("Objective with id was not found.");

            _objectiveRepository.SoftDelete(Guid.Parse(objId));
            _uow.Save();
        }
    }
}
