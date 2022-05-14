using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class MilestoneService : IMilestoneService
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Milestone> _milRepository;
        private readonly IRepository<Deliverable> _delivRepository;
        private readonly Func<IQueryable<Milestone>, IIncludableQueryable<Milestone, object>> _includes;

        public MilestoneService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _milRepository = _uow.GetRepository<Milestone>();
            _delivRepository = _uow.GetRepository<Deliverable>();
            _mapper = mapper;
            _includes = milestone => milestone.Include(m => m.Deliverables);
        }

        public IEnumerable<MilestoneResponse> GetAllMilestonesByProject(string projectId)
        {
            return _milRepository.Find(o => o.ProjectId == Guid.Parse(projectId), _includes)
                .Select(milEntity => _mapper.Map<MilestoneResponse>(milEntity))
                .ToList();
        }

        public IEnumerable<MilestoneResponse> GetAllMilestones()
        {
            return _milRepository.GetAllWithDeleted(_includes)
                .Select(milEntity => _mapper.Map<MilestoneResponse>(milEntity))
                .ToList();
        }

        public MilestoneResponse AddMilestone(MilestoneRequest milRequest)
        {
            var milEntity = _milRepository.FindWithDeleted(mil => mil.Activity == milRequest.Activity)
                .FirstOrDefault();

            if (milEntity != null)
            {
                throw new AlreadyExistsException<Milestone>("Milestone with such activity already exists.");
            }

            milEntity = _mapper.Map<Milestone>(milRequest);
            var id = _milRepository.CreateWithVal(milEntity);
            _uow.Save();

            foreach (var del in milRequest.DeliverablesId.Select(delId =>
                         _delivRepository.Find(d => d.Id == Guid.Parse(delId))
                         .FirstOrDefault())
                         .Where(del => del != null))
            {
                del.MilestoneId = id;
                _delivRepository.Update(del);
            }
            _uow.Save();

            return _mapper.Map<MilestoneResponse>(_milRepository.Find(ob => ob.Id == milEntity.Id, _includes).FirstOrDefault());
        }

        public MilestoneResponse UpdateMilestone(MilestoneRequest milRequest, string milId)
        {
            var milEntity = _milRepository.Find(mil =>
                    mil.Id == Guid.Parse(milId), _includes)
                .FirstOrDefault();

            _ = milEntity ?? throw new NotFoundException<Objective>("Milestone with id was not found.");

            foreach (var del in milEntity.Deliverables.ToList()
                         .Where(del => milRequest.DeliverablesId
                             .All(id => id != del.Id.ToString())))
            {
                del.MilestoneId = null;
                _delivRepository.Update(del);
                _uow.Save();
            }

            milEntity = _mapper.Map<Milestone>(milRequest);
            milEntity.Id = Guid.Parse(milId);

            foreach (var del in
                     from delId in milRequest.DeliverablesId
                     where milEntity.Deliverables.All(del => del.Id != Guid.Parse(delId))
                     select _delivRepository.Find(del => del.Id == Guid.Parse(delId))
                         .FirstOrDefault())
            {
                del.MilestoneId = Guid.Parse(milId);
                _delivRepository.Update(del);
            }

            _milRepository.Update(milEntity);
            _uow.Save();

            return _mapper.Map<MilestoneResponse>(_milRepository.Find(ob => ob.Id == milEntity.Id, _includes).FirstOrDefault());
        }
        public void DeleteMilestone(string milId)
        {
            var milEntity = _milRepository.FindWithDeleted(mil => mil.Id.ToString() == milId)
                .FirstOrDefault();
            _ = milEntity ?? throw new NotFoundException<Objective>("Milestone with id was not found.");

            _milRepository.SoftDelete(Guid.Parse(milId));
            _uow.Save();
        }
    }
}
