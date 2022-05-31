using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Dtos.Responses;
using Domain.Models.Dtos.Stakeholder;
using Domain.Models.Entities;
using Domain.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Models.Constants;

namespace Domain.Services
{
    public class StakeholdersService : IStakeholdersService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Stakeholder> _stakeholderRepository;
        private readonly IRepository<ProjectStakeholder> _projStakeholdersRepository;
        private readonly ILoggerManager _logger;
        private readonly Func<IQueryable<ProjectStakeholder>, IIncludableQueryable<ProjectStakeholder, object>> _includesStp;
        private readonly Func<IQueryable<Stakeholder>, IIncludableQueryable<Stakeholder, object>> _includesSt;

        public StakeholdersService(IUnitOfWork uow, IMapper mapper, ILoggerManager logger)
        {
            _uow = uow;
            _stakeholderRepository = _uow.GetRepository<Stakeholder>();
            _projStakeholdersRepository = _uow.GetRepository<ProjectStakeholder>();
            _mapper = mapper;
            _logger = logger;
            _includesStp = stakeholders => stakeholders
                .Include(s => s.Project)
                .Include(s => s.Stakeholder);
            _includesSt = stakeholders => stakeholders
                .Include(s => s.ProjectStakeholders)
                .ThenInclude(s => s.Project);
        }

        public IEnumerable<StakeholderResponse> GetStakeholders(string managerId, IEnumerable<string> roles)
        {
            List<StakeholderResponse> stakeholders;

            _ = roles ?? throw new NullReferenceException
                (Strings.GetNullRefExcMethodParameterMessage("roles"));

            var roleList = roles.ToList();

            if (roleList.Contains(Strings.ManagerRole))
            {
                stakeholders = _projStakeholdersRepository
                    .Find(prSt => prSt.Project.ManagerId == managerId, _includesStp)
                    .Select(empEntity => _mapper.Map<StakeholderResponse>(empEntity))
                    .ToList();
            }
            else if (roleList.Contains(Strings.LeadRole))
            {
                stakeholders = _projStakeholdersRepository
                    .GetAll(_includesStp)
                    .Select(empEntity => _mapper.Map<StakeholderResponse>(empEntity))
                    .ToList();
            }
            else
            {
                stakeholders = _projStakeholdersRepository
                    .GetAllWithDeleted(_includesStp)
                    .Select(empEntity => _mapper.Map<StakeholderResponse>(empEntity))
                    .ToList();
            }

            stakeholders.ForEach(st => st.Projects = _projStakeholdersRepository
                .Find(stp => stp.StakeholderId == Guid.Parse(st.Id))
                .Select(stp => _mapper.Map<ProjectStakeholderResponse>(stp))
                .ToList());

            return stakeholders;
        }

        public IEnumerable<StakeholderResponse> GetStakeholders(string projectId)
        {
            return _projStakeholdersRepository
                .Find(prSt => prSt.ProjectId != Guid.Parse(projectId), _includesStp)
                .Select(empEntity => _mapper.Map<StakeholderResponse>(empEntity))
                .ToList();
        }

        public StakeholderResponse AddStakeholder(StakeholderRequest stRequest)
        {
            var stEntity = _stakeholderRepository
                .FindWithDeleted(st => st.Email == stRequest.Email)
                .FirstOrDefault();

            if (stEntity != null)
            {
                throw new AlreadyExistsException<Stakeholder>("Stakeholder with such email already exists.");
            }

            stEntity = _mapper.Map<Stakeholder>(stRequest);

            _stakeholderRepository.Create(stEntity);
            _uow.Save();

            var stakeholder = _stakeholderRepository
                .Find(st => st.Id == stEntity.Id)
                .FirstOrDefault();
            _projStakeholdersRepository.Create(
                new ProjectStakeholder { StakeholderId = stakeholder.Id, ProjectId = new Guid(stRequest.ProjectId) });
            _uow.Save();

            return _mapper.Map<StakeholderResponse>(stakeholder);
        }

        public StakeholderResponse AddStakeholderToProject(StakeholderProjectRequest projStakeholderRequest)
        {
            _projStakeholdersRepository.Create(
                new ProjectStakeholder
                {
                    StakeholderId = Guid.Parse(projStakeholderRequest.StakeholderId),
                    ProjectId = Guid.Parse(projStakeholderRequest.ProjectId)
                });
            _uow.Save();

            return _stakeholderRepository
                .Find(st => st.Id.ToString() == projStakeholderRequest.StakeholderId)
                .Select(st => _mapper.Map<StakeholderResponse>(st))
                .FirstOrDefault();
        }

        public StakeholderResponse UpdateStakeholder(StakeholderRequest stRequest, string stId)
        {
            var stEntity = _stakeholderRepository
                .Find(st => st.Id.ToString() == stId)
                .FirstOrDefault();
            _ = stEntity ?? throw new NotFoundException<Stakeholder>("Stakeholder with id was not found.");


            stEntity = _mapper.Map<Stakeholder>(stRequest);
            stEntity.Id = Guid.Parse(stId);
            _stakeholderRepository.Update(stEntity);
            _uow.Save();

            return _mapper.Map<StakeholderResponse>(_stakeholderRepository.Find(st => st.Id.ToString() == stId).FirstOrDefault());
        }


        public void DeleteStakeholder(StakeholderProjectRequest stRequest)
        {
            var stEntity = _stakeholderRepository.FindWithDeleted(st => st.Id.ToString() == stRequest.StakeholderId)
                .FirstOrDefault();
            _ = stEntity ?? throw new NotFoundException<Stakeholder>("Stakeholder with id was not found.");

            _stakeholderRepository.SoftDelete(Guid.Parse(stRequest.StakeholderId));

            var projSt = _projStakeholdersRepository
                .FirstOrDefault(st => st.StakeholderId == Guid.Parse(stRequest.StakeholderId)
                && st.ProjectId == Guid.Parse(stRequest.ProjectId));
            _ = projSt ?? throw new NotFoundException<ProjectStakeholder>
                ("Such pair of stakeholder and project doesn't exist");
            _projStakeholdersRepository.SoftDelete(projSt.Id);

            _uow.Save();
        }
    }
}
