using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Dtos.Responses;
using Domain.Models.Dtos.Stakeholder;
using Domain.Models.Entities;
using Domain.Models.Exceptions;
using Domain.Models.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Services
{
    public class StakeholdersService : IStakeholdersService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Stakeholder> _stakeholderRepository;
        private readonly IRepository<ProjectStakeholder> _projStakeholdersRepository;
        private readonly Func<IQueryable<ProjectStakeholder>, IIncludableQueryable<ProjectStakeholder, object>> _includesStp;
        private readonly Func<IQueryable<Stakeholder>, IIncludableQueryable<Stakeholder, object>> _includesSt;

        public StakeholdersService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _stakeholderRepository = _uow.GetRepository<Stakeholder>();
            _projStakeholdersRepository = _uow.GetRepository<ProjectStakeholder>();
            _mapper = mapper;
            _includesStp = stakeholders => stakeholders
                .Include(s => s.Project)
                .Include(s => s.Stakeholder);
            _includesSt = stakeholders => stakeholders
                .Include(s => s.ProjectStakeholders)
                .ThenInclude(s => s.Project);
        }

        public IEnumerable<StakeholderResponse> GetStakeholders(StakeholderFiteringParam param = null)
        {
            List<StakeholderResponse> stakeholders;

            var stakeholdersQuery = _stakeholderRepository.GetAll(_includesSt).AsQueryable();

            if (!string.IsNullOrEmpty(param.SearchBy.Trim().ToLowerInvariant()))
            {
                stakeholdersQuery = stakeholdersQuery
                    .Where(st => st.Name.ToLower().Contains(param.SearchBy)
                            || st.Email.ToLower().Contains(param.SearchBy)
                            || st.Notes.ToLower().Contains(param.SearchBy));
            }

            stakeholders = stakeholdersQuery.Select(stakEntity => _mapper.Map<StakeholderResponse>(stakEntity))
                    .ToList();

            stakeholders.ForEach(st => st.Projects = _projStakeholdersRepository
                .Find(stp => stp.StakeholderId.ToString() == st.Id, _includesStp)
                .Select(stp => _mapper.Map<ProjectStakeholderResponse>(stp))
                .ToList());

            if (param.ProjectIds == null)
            {
                return stakeholders;
            }
            else
            {
                return stakeholders.Where(pr => param.ProjectIds.Any(id => pr.Projects.Any(pr => pr.Id == id.ToString()))).ToList();
            }
        }

        public IEnumerable<StakeholderResponse> GetStakeholders(Guid prId)
        {
            return _projStakeholdersRepository.Find(prSt => prSt.ProjectId == prId, _includesStp)
                .Select(empEntity => _mapper.Map<StakeholderResponse>(empEntity)).ToList();
        }

        public StakeholderResponse AddStakeholder(StakeholderRequest stRequest)
        {
            var stEntity = _stakeholderRepository.FindWithDeleted(st => st.Email == stRequest.Email).FirstOrDefault();

            if (stEntity != null)
            {
                throw new AlreadyExistsException("Stakeholder with such email already exists", "email");
            }

            stEntity = _mapper.Map<Stakeholder>(stRequest);

            _stakeholderRepository.Create(stEntity);
            _uow.Save();

            var stakeholder = _stakeholderRepository.Find(st => st.Id == stEntity.Id).FirstOrDefault();

            return _mapper.Map<StakeholderResponse>(stakeholder);
        }

        public StakeholderResponse RemoveStakeholderFromProject(Guid prId, Guid stId)
        {
            var projectStak = _projStakeholdersRepository.Find(prSt => prSt.ProjectId == prId
                && prSt.StakeholderId == stId).FirstOrDefault();

            _ = projectStak ?? throw new NotFoundException("Stakeholder wasn't found");

            _projStakeholdersRepository.Delete(projectStak);
            _uow.Save();

            return _stakeholderRepository.Find(st => st.Id == stId).Select(st => _mapper.Map<StakeholderResponse>(st))
                .FirstOrDefault();
        }

        public StakeholderResponse UpdateStakeholder(StakeholderRequest stRequest, Guid stId)
        {
            var stEntity = _stakeholderRepository.Find(st => st.Id == stId).FirstOrDefault();

            _ = stEntity ?? throw new NotFoundException("Stakeholder was not found");

            stEntity = _mapper.Map<Stakeholder>(stRequest);

            stEntity.Id = stId;
            _stakeholderRepository.Update(stEntity);
            _uow.Save();

            return _mapper.Map<StakeholderResponse>(_stakeholderRepository.Find(st => st.Id == stId, _includesSt)
                .FirstOrDefault());
        }


        public void DeleteStakeholder(Guid stId)
        {
            var stEntity = _stakeholderRepository.Find(st => st.Id == stId, _includesSt).FirstOrDefault();

            _ = stEntity ?? throw new NotFoundException("Stakeholder was not found");

            if (stEntity.ProjectStakeholders != null)
            {
                throw new AlreadyExistsException("Stakeholder has been already assigned to some projects. To delete the stakeholder reassign it from projects.");
            }

            _stakeholderRepository.SoftDelete(stId);

            _uow.Save();
        }

        public StakeholderResponse AddStakeholderToProject(Guid prId, Guid stId)
        {
            _projStakeholdersRepository.Create(new ProjectStakeholder
            {
                StakeholderId = stId,
                ProjectId = prId
            });
            _uow.Save();

            return _stakeholderRepository.Find(st => st.Id == stId).Select(st => _mapper.Map<StakeholderResponse>(st))
                .FirstOrDefault();
        }

    }
}
