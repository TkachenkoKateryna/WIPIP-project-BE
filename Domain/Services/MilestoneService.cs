using Domain.Models.Exceptions;
using AutoMapper;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Services
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

        public MilestoneResponse AddMilestone(MilestoneRequest mRequest)
        {
            var mEntity = _milRepository.Find(m => m.Activity == mRequest.Activity && m.ProjectId == mRequest.ProjectId).FirstOrDefault();

            if (mEntity != null)
            {
                throw new AlreadyExistsException("Milestone with such activity exists", "activity");
            }

            mEntity = _mapper.Map<Milestone>(mRequest);
            var id = _milRepository.CreateWithVal(mEntity);
            _uow.Save();

            foreach (var d in mRequest.DeliverablesId.Select(dId => _delivRepository.Find(d => d.Id == dId))
                         .FirstOrDefault().Where(d => d != null))
            {
                d.MilestoneId = id;
                _delivRepository.Update(d);
            }
            _uow.Save();

            return _mapper.Map<MilestoneResponse>(_milRepository.Find(m => m.Id == id, _includes).FirstOrDefault());
        }

        public MilestoneResponse UpdateMilestone(MilestoneRequest mRequest, Guid mId)
        {
            var mEntity = _milRepository.Find(m => m.Id == mId, _includes).FirstOrDefault();

            _ = mEntity ?? throw new NotFoundException("Milestone was not found.");

            if (_milRepository.Find(m => m.Activity == mRequest.Activity && m.Id != mId && m.ProjectId == m.ProjectId).Any())
            {
                throw new AlreadyExistsException("Milestone with such title already exists", "activity");
            }

            foreach (var d in mEntity.Deliverables.ToList().Where(del => mRequest.DeliverablesId.All(id => id != del.Id)))
            {
                d.MilestoneId = null;
                _delivRepository.Update(d);
                _uow.Save();
            }

            mEntity = _mapper.Map<Milestone>(mRequest);
            mEntity.Id = mId;

            foreach (var d in
                     from dId in mRequest.DeliverablesId
                     where mEntity.Deliverables.All(d => d.Id != dId)
                     select _delivRepository.Find(d => d.Id == dId).FirstOrDefault())
            {
                d.MilestoneId = mId;
                _delivRepository.Update(d);
            }

            _milRepository.Update(mEntity);
            _uow.Save();

            return _mapper.Map<MilestoneResponse>(_milRepository.Find(m => m.Id == mId, _includes).FirstOrDefault());
        }

        public void DeleteMilestone(Guid mId)
        {
            var mEntity = _milRepository.FindWithDeleted(m => m.Id == mId).FirstOrDefault();
            _ = mEntity ?? throw new NotFoundException("Milestone was not found.");

            _milRepository.SoftDelete(mId);
            _uow.Save();
        }
    }
}
