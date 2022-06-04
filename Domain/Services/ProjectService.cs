using AutoMapper;
using Domain.Models.Dtos.Project;
using Domain.Models.Dtos.Responses;
using Domain.Models.Dtos.Stakeholder;
using Domain.Models.Entities;
using Domain.Models.Entities.Identity;
using Domain.Models.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Models.Constants;

namespace Domain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<ProjectStakeholder> _projStakeholderRepository;
        private readonly IRepository<ProjectRisk> _projRiskRepository;
        private readonly IRepository<ProjectCandidate> _projCandidateRepository;
        private readonly IPDFService _pdfService;
        private readonly UserManager<User> _userManager;
        private readonly Func<IQueryable<Project>, IIncludableQueryable<Project, object>> _projIncludes;
        private readonly Func<IQueryable<ProjectStakeholder>, IIncludableQueryable<ProjectStakeholder, object>> _projStakIncludes;
        private readonly Func<IQueryable<ProjectRisk>, IIncludableQueryable<ProjectRisk, object>> _projRiskIncludes;
        private readonly Func<IQueryable<ProjectCandidate>, IIncludableQueryable<ProjectCandidate, object>> _projCandInclude;

        public ProjectService(IUnitOfWork uow, IMapper mapper, IPDFService pdfService, UserManager<User> userManager

        )
        {
            _uow = uow;
            _projectRepository = _uow.GetRepository<Project>();
            _projRiskRepository = _uow.GetRepository<ProjectRisk>();
            _projCandidateRepository = _uow.GetRepository<ProjectCandidate>();
            _projStakeholderRepository = _uow.GetRepository<ProjectStakeholder>();
            _mapper = mapper;
            _pdfService = pdfService;
            _userManager = userManager;
            _projIncludes = project => project
                .Include(p => p.Objectives)
                .Include(p => p.Assumptions)
                .Include(p => p.Deliverables)
                .Include(p => p.Manager).ThenInclude(p => p.Role)
                .Include(p => p.Milestones).ThenInclude(m => m.Deliverables)
                .Include(p => p.ProjectStakeholders).ThenInclude(st => st.Stakeholder);
            _projRiskIncludes = risk => risk
                .Include(r => r.Risk).ThenInclude(r => r.RiskCategory);
            _projStakIncludes = stak => stak
                .Include(st => st.Stakeholder);
            _projCandInclude = cand => cand
                .Include(c => c.Skill)
                .Include(c => c.Employee);
        }

        public IEnumerable<ProjectsResponse> GetProjects(string managerId, IEnumerable<string> roles)
        {
            List<ProjectsResponse> projects;

            _ = roles ?? throw new NullReferenceException
                (Strings.GetNullRefExcMethodParameterMessage("roles"));

            var roleList = roles.ToList();

            if (roleList.Contains(Strings.ManagerRole))
            {
                projects = _projectRepository
                    .Find(p => p.ManagerId == managerId, _projIncludes)
                    .Select(projEntity => _mapper.Map<ProjectsResponse>(projEntity))
                    .ToList();
            }
            else if (roleList.Contains(Strings.LeadRole))
            {
                projects = _projectRepository
                  .GetAll(_projIncludes)
                  .Select(projEntity => _mapper.Map<ProjectsResponse>(projEntity))
                  .ToList();
            }
            else
            {
                projects = _projectRepository
                    .GetAllWithDeleted(_projIncludes)
                    .Select(projEntity => _mapper.Map<ProjectsResponse>(projEntity))
                    .ToList();
            }

            projects.ForEach(p => p.Stakeholders = _projStakeholderRepository
                .Find(pr => pr.ProjectId == Guid.Parse(p.Id), _projStakIncludes)
                .Select(pr => pr.Stakeholder.Name).ToList());

            return projects;
        }

        public ProjectResponse GetProjectById(string projectId)
        {
            var project = _projectRepository
                .Find(p => p.Id == Guid.Parse(projectId), _projIncludes)
                .Select(empEntity => _mapper.Map<ProjectResponse>(empEntity))
                .FirstOrDefault();

            project.Stakeholders = GetProjectStakeholders(projectId);

            project.Risks = GetProjectRisks(projectId);

            project.Candidates = GetProjectCandidates(projectId);

            return project;
        }

        public ProjectResponse AddProject(ProjectRequest projectRequest)
        {
            var projectEntity = _projectRepository
                .FindWithDeleted(pr => pr.Title == projectRequest.Title)
                .FirstOrDefault();

            if (projectEntity != null)
            {
                throw new AlreadyExistsException<Milestone>
                    ($"Project with such title {projectRequest.Title} already exists.");
            }

            projectEntity = _mapper.Map<Project>(projectRequest);

            _projectRepository.Create(projectEntity);
            _uow.Save();

            return _mapper.Map<ProjectResponse>(projectEntity);
        }

        public ProjectResponse UpdateProject(ProjectRequest projectRequest, string projectId)
        {
            var projectEntity = _projectRepository
                .Find(project => project.Id == Guid.Parse(projectId), _projIncludes)
                .FirstOrDefault();

            _ = projectEntity ?? throw new NotFoundException<Project>
                ($"Project with id {projectId} was not found.");

            projectEntity.Title = projectRequest.Title;
            projectEntity.Description = projectRequest.Description;
            projectEntity.ManagerId = projectRequest.ManagerId;

            _projectRepository.Update(projectEntity);
            _uow.Save();

            return GetProjectById(projectId);

        }

        public void DeleteProject(string projectId)
        {
            var projEntity = _projectRepository
                .FindWithDeleted(proj => proj.Id.ToString() == projectId)
                .FirstOrDefault();
            _ = projEntity ?? throw new NotFoundException<Project>
                ($"Project with id {projectId} was not found.");

            _projectRepository.SoftDelete(Guid.Parse(projectId));
            _uow.Save();
        }

        public ProjectResponse CalculateProjectBudget(string projectId)
        {

            var project = GetProject(projectId);
            var candidates = GetProjectCandidates(projectId);

            var income = CalculateMonthlyIncome(candidates);
            var outcome = CalculateMonthlyOutcome(candidates);
            var profit = CalculateMonthlyProfit(income, outcome);

            project.MonthlyIncome = income;
            project.MonthlyOutcome = outcome;
            project.MonthlyProfit = profit;

            _projectRepository.Update(project);
            _uow.Save();

            return GetProjectById(projectId);
        }

        public void SetProjectStatus(string projectId, ProjectStatus status)
        {
            var projectEntity = _projectRepository
                .Find(p => p.Id == Guid.Parse(projectId))
                .FirstOrDefault();

            _ = projectEntity ?? throw new NotFoundException<Project>($"Project with id {projectId} was not found.");

            projectEntity.Status = status;
            _projectRepository.Update(projectEntity);
            _uow.Save();
        }


        private double CalculateMonthlyIncome(List<CandidateResponse> candidates)
        {
            return (candidates.Sum(c => c.ExternalRate * (8 * c.FTE) * 21));
        }

        private double CalculateMonthlyOutcome(List<CandidateResponse> candidates)
        {
            return (candidates.Sum(c => (c.InternalRate * (8 * c.FTE) * 21) + (6 * 21)));
        }

        private double CalculateMonthlyProfit(double income, double outcome)
        {
            return Math.Round(((income - outcome) / outcome) * 100, 2);
        }

        private Project GetProject(string projectId)
        {
            return _projectRepository
                .Find(p => p.Id == Guid.Parse(projectId))
                .FirstOrDefault();
        }

        private List<CandidateResponse> GetProjectCandidates(string projectId)
        {
            return _projCandidateRepository
                .Find(pc => pc.ProjectId == Guid.Parse(projectId), _projCandInclude)
                .Select(projectEntity => _mapper.Map<CandidateResponse>(projectEntity))
                .ToList();
        }

        private List<RiskResponse> GetProjectRisks(string projectId)
        {
            return _projRiskRepository
                .Find(r => r.ProjectId == Guid.Parse(projectId), _projRiskIncludes)
                .Select(empEntity => _mapper.Map<RiskResponse>(empEntity))
                .ToList();
        }

        private List<StakeholderResponse> GetProjectStakeholders(string projectId)
        {
            return _projStakeholderRepository
                .Find(p => p.ProjectId == Guid.Parse(projectId), _projStakIncludes)
                .Select(empEntity => _mapper.Map<StakeholderResponse>(empEntity))
                .ToList();
        }
    }
}
