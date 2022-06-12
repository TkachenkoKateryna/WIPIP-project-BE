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

        public IEnumerable<StakeholderResponse> GetStakeholders()
        {
            List<StakeholderResponse> stakeholders;

            stakeholders = _stakeholderRepository
                .GetAll(_includesSt)
                .Select(empEntity => _mapper.Map<StakeholderResponse>(empEntity))
                .ToList();

            stakeholders.ForEach(st => st.Projects = _projStakeholdersRepository
                .Find(stp => stp.StakeholderId == Guid.Parse(st.Id))
                .Select(stp => _mapper.Map<ProjectStakeholderResponse>(stp))
                .ToList());

            return stakeholders;
        }

        public IEnumerable<StakeholderResponse> GetStakeholders(string projectId)
        {
            return _projStakeholdersRepository
                .Find(prSt => prSt.ProjectId == Guid.Parse(projectId), _includesStp)
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

            return _mapper.Map<StakeholderResponse>(stakeholder);
        }

        public StakeholderResponse RemoveStakeholderFromProject(string projectId, string stakeholderId)
        {
            var projectStak = _projStakeholdersRepository
                .Find(ps => ps.ProjectId == Guid.Parse(projectId)
                && ps.StakeholderId == Guid.Parse(stakeholderId))
                .FirstOrDefault();
            _ = projectStak ?? throw new NotFoundException<ProjectStakeholder>("Stakeholder in project wasn't found");

            _projStakeholdersRepository.Delete(projectStak);
            _uow.Save();

            var res = _stakeholderRepository
                .Find(st => st.Id.ToString() == stakeholderId)
                .Select(st => _mapper.Map<StakeholderResponse>(st))
                .FirstOrDefault();

            return _stakeholderRepository
                .Find(st => st.Id.ToString() == stakeholderId)
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

            var res = _mapper.Map<StakeholderResponse>(_stakeholderRepository.Find(st => st.Id.ToString() == stId, _includesSt).FirstOrDefault());
            return _mapper.Map<StakeholderResponse>(_stakeholderRepository.Find(st => st.Id.ToString() == stId, _includesSt).FirstOrDefault());
        }


        public void DeleteStakeholder(string stakeholderId)
        {
            var stEntity = _stakeholderRepository
                .FindWithDeleted(st => st.Id.ToString() == stakeholderId)
                .FirstOrDefault();
            _ = stEntity ?? throw new NotFoundException<Stakeholder>("Stakeholder with id was not found.");

            _stakeholderRepository.SoftDelete(Guid.Parse(stakeholderId));

            var projSt = _projStakeholdersRepository
                .Find(st => st.StakeholderId == Guid.Parse(stakeholderId))
                .ToList(); ;
            _ = projSt ?? throw new NotFoundException<ProjectStakeholder>
                ("Such pair of stakeholder and project doesn't exist");

            foreach (var st in projSt)
            {
                _projStakeholdersRepository.SoftDelete(st.Id);
            }

            _uow.Save();
        }


        public StakeholderResponse AddStakeholderToProject(string projectId, string stakeholderId)
        {
            _projStakeholdersRepository.Create(
                new ProjectStakeholder
                {
                    StakeholderId = Guid.Parse(stakeholderId),
                    ProjectId = Guid.Parse(projectId)
                });
            _uow.Save();

            return _stakeholderRepository
                .Find(st => st.Id.ToString() == stakeholderId)
                .Select(st => _mapper.Map<StakeholderResponse>(st))
                .FirstOrDefault();
        }

    }
}
