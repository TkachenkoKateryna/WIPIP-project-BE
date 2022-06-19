using Domain.Models.Exceptions;
using AutoMapper;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
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

        public IEnumerable<DeliverableResponse> GetDeliverablesByProject(Guid projectId)
        {
            return _delivRepository.Find(d => d.ProjectId == projectId)
                .Select(delEntity => _mapper.Map<DeliverableResponse>(delEntity))
                .ToList();
        }

        public DeliverableResponse AddDeliverable(DeliverableRequest delRequest)
        {
            var delEntity = _delivRepository.Find(d => d.Title == delRequest.Title).FirstOrDefault();

            if (delEntity != null)
            {
                throw new AlreadyExistsException("Deliverable with such title already exists", "title");
            }

            delEntity = _mapper.Map<Deliverable>(delRequest);

            var id = _delivRepository.CreateWithVal(delEntity);
            _uow.Save();
            return _mapper.Map<DeliverableResponse>(_delivRepository.Find(ob => ob.Id == id).FirstOrDefault());
        }

        public DeliverableResponse UpdateDeliverable(DeliverableRequest delRequest, Guid delId)
        {
            var delEntity = _delivRepository.Find(d => d.Id == delId).FirstOrDefault();

            _ = delEntity ?? throw new NotFoundException("Deliverable was not found");

            delEntity = _mapper.Map<Deliverable>(delRequest);

            delEntity.Id = delId;
            _delivRepository.Update(delEntity);
            _uow.Save();

            return _mapper.Map<DeliverableResponse>(_delivRepository.Find(del => del.Id == delId).FirstOrDefault());
        }

        public void DeleteDeliverable(Guid delId)
        {
            var delEntity = _delivRepository.Find(d => d.Id == delId).FirstOrDefault();

            _ = delEntity ?? throw new NotFoundException("Deliverable was not found");

            _delivRepository.Delete(delEntity);
            _uow.Save();
        }
    }
}
