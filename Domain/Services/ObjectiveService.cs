using Domain.Models.Exceptions;
using AutoMapper;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
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

        public ObjectiveResponse AddObjective(ObjectiveRequest obRequest)
        {
            var obEntity = _objectiveRepository.Find(ob => ob.Title == obRequest.Title && ob.ProjectId == obRequest.ProjectId)
                .FirstOrDefault();

            if (obEntity != null)
            {
                throw new AlreadyExistsException("Objective with such title already exists", "title");
            }

            obEntity = _mapper.Map<Objective>(obRequest);

            var obId = _objectiveRepository.CreateWithVal(obEntity);
            _uow.Save();

            return _mapper.Map<ObjectiveResponse>(_objectiveRepository.Find(ob => ob.Id == obId).FirstOrDefault());
        }

        public ObjectiveResponse UpdateObjective(ObjectiveRequest obRequest, Guid obId)
        {
            var obEntity = _objectiveRepository.Find(ob => ob.Id == obId).FirstOrDefault();

            _ = obEntity ?? throw new NotFoundException("Objective was not found");

            if (_objectiveRepository.Find(ob => ob.Title == obRequest.Title && ob.Id != obId && ob.ProjectId == obRequest.ProjectId).Any()) 
            {
                throw new AlreadyExistsException("Objective with such title already exists", "title");
            }

            obEntity = _mapper.Map<Objective>(obRequest);

            obEntity.Id = obId;
            _objectiveRepository.Update(obEntity);
            _uow.Save();

            return _mapper.Map<ObjectiveResponse>(_objectiveRepository.Find(ob => ob.Id == obId).FirstOrDefault());
        }

        public void DeleteObjective(Guid obId)
        {
            var obEntity = _objectiveRepository.Find(ob => ob.Id == obId).FirstOrDefault();

            _ = obEntity ?? throw new NotFoundException("Objective was not found");

            _objectiveRepository.SoftDelete(obId);
            _uow.Save();
        }
    }
}
