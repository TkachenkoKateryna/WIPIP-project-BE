using Domain.Exceptions;
using AutoMapper;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class DeliverablesService : IDeliverablesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Deliverable> _delivRepository;

        public DeliverablesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _delivRepository = _uow.GetRepository<Deliverable>();
            _mapper = mapper;
        }

        public IEnumerable<DeliverableResponse> GetAllDeliverables()
        {
            return _delivRepository.GetAllWithDeleted()
                .Select(delEntity => _mapper.Map<DeliverableResponse>(delEntity))
                .ToList();
        }

        public DeliverableResponse AddDeliverable(DeliverableRequest delRequest)
        {
            var delEntity = _delivRepository.FindWithDeleted(del => del.Title == delRequest.Title)
                .FirstOrDefault();

            if (delEntity != null)
            {
                throw new AlreadyExistsException<Objective>("Deliverable with such title already exists.");
            }

            delEntity = _mapper.Map<Deliverable>(delRequest);

            _delivRepository.Create(delEntity);

            _uow.Save();

            return _mapper.Map<DeliverableResponse>(_delivRepository.Find(ob => ob.Id == delEntity.Id).FirstOrDefault());
        }

        public DeliverableResponse UpdateDeliverable(DeliverableRequest delRequest, string delId)
        {
            var delEntity = _delivRepository.Find(ob => ob.Id.ToString() == delId)
                 .FirstOrDefault();
            _ = delEntity ?? throw new NotFoundException<Objective>("Deliverable with id was not found.");

            delEntity = _mapper.Map<Deliverable>(delRequest);
            delEntity.Id = Guid.Parse(delId);
            _delivRepository.Update(delEntity);
            _uow.Save();


            return _mapper.Map<DeliverableResponse>(_delivRepository.Find(del => del.Id.ToString() == delId).FirstOrDefault());
        }

        public void DeleteDeliverable(string delId)
        {
            var delEntity = _delivRepository.FindWithDeleted(del => del.Id.ToString() == delId)
                .FirstOrDefault();
            _ = delEntity ?? throw new NotFoundException<Objective>("Deliverable with id was not found.");

            _delivRepository.SoftDelete(Guid.Parse(delId));
            _uow.Save();
        }
    }
}
