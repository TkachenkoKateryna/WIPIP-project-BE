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
using Domain.Models.Filters;

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
        private readonly Func<IQueryable<Project>, IIncludableQueryable<Project, object>> _projIncludes;
        private readonly Func<IQueryable<ProjectStakeholder>, IIncludableQueryable<ProjectStakeholder, object>> _projStakIncludes;
        private readonly Func<IQueryable<ProjectRisk>, IIncludableQueryable<ProjectRisk, object>> _projRiskIncludes;
        private readonly Func<IQueryable<ProjectCandidate>, IIncludableQueryable<ProjectCandidate, object>> _projCandInclude;

        private const int DailyHours = 8;
        private const int AvarageNumbWorkDaysMonth = 21;
        private const int MonthExpensPerEmployee = 6;
        private const int HundredPercent = 100;
        private const int RoundToHundreds = 2;


        public ProjectService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _projectRepository = _uow.GetRepository<Project>();
            _projRiskRepository = _uow.GetRepository<ProjectRisk>();
            _projCandidateRepository = _uow.GetRepository<ProjectCandidate>();
            _projStakeholderRepository = _uow.GetRepository<ProjectStakeholder>();
            _mapper = mapper;
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

        public IEnumerable<ProjectsResponse> GetProjects(string managerId, string role, ProjectFilteringParams param = null)
        {
            List<ProjectsResponse> projects;

            var projectsQuery = _projectRepository.GetAll(_projIncludes).AsQueryable();

            if (!string.IsNullOrEmpty(param.SearchBy.Trim().ToLowerInvariant()))
            {
                projectsQuery = projectsQuery.Where(e => e.Title.ToLower().Contains(param.SearchBy));
            }

            if (param.Statuses != null)
            {
                projectsQuery = projectsQuery.Where(pr => param.Statuses.Any(status => status == (int)pr.Status));
            }

            if (role is Strings.ManagerRole)
            {
                projects = projectsQuery.Where(p => p.ManagerId == managerId && p.IsDeleted == false)
                    .Select(projEntity => _mapper.Map<ProjectsResponse>(projEntity)).ToList();
            }
            else
            {
                if (param.UsersIds == null)
                {
                    projects = projectsQuery.Select(projEntity => _mapper.Map<ProjectsResponse>(projEntity))
                        .ToList();
                }
                else
                {
                    projects = projectsQuery
                        .Where(pr => param.UsersIds.Any(id => id == pr.ManagerId))
                        .Select(projEntity => _mapper.Map<ProjectsResponse>(projEntity))
                        .ToList();
                }
            }

            projects.ForEach(p => p.Stakeholders = _projStakeholderRepository
                .Find(pr => pr.ProjectId == Guid.Parse(p.Id), _projStakIncludes)
                .Select(pr => pr.Stakeholder.Name).ToList());

            return projects;
        }

        public ProjectResponse GetProjectById(Guid prId)
        {
            var prResponse = _projectRepository.Find(p => p.Id == prId, _projIncludes)
                .Select(pEntity => _mapper.Map<ProjectResponse>(pEntity)).FirstOrDefault();

            prResponse.Stakeholders = GetProjectStakeholders(prId);
            prResponse.Risks = GetProjectRisks(prId);
            prResponse.Candidates = GetProjectCandidates(prId);

            return prResponse;
        }

        public ProjectResponse AddProject(ProjectRequest projectRequest)
        {
            var projectEntity = _projectRepository
                .FindWithDeleted(pr => pr.Title == projectRequest.Title)
                .FirstOrDefault();

            if (projectEntity != null)
            {
                throw new AlreadyExistsException
                    ($"Project with such title {projectRequest.Title} already exists.");
            }

            projectEntity = _mapper.Map<Project>(projectRequest);
            projectEntity.Status = ProjectStatus.Draft;

            var id = _projectRepository.CreateWithVal(projectEntity);
            _uow.Save();

            return _mapper.Map<ProjectResponse>(_projectRepository.Find(p => p.Id == id, _projIncludes).FirstOrDefault());
        }

        public ProjectResponse UpdateProject(ProjectRequest prRequest, Guid prId)
        {
            var prEntity = _projectRepository.Find(pr => pr.Id == prId, _projIncludes)
                .FirstOrDefault();

            _ = prEntity ?? throw new NotFoundException("Project was not found");

            prEntity.Title = prRequest.Title;
            prEntity.Description = prRequest.Description;
            prEntity.ManagerId = prRequest.ManagerId;

            _projectRepository.Update(prEntity);
            _uow.Save();

            return GetProjectById(prId);

        }

        public void DeleteProject(Guid prId)
        {
            var prEntity = _projectRepository.Find(pr => pr.Id == prId).FirstOrDefault();

            _ = prEntity ?? throw new NotFoundException("Project was not found");

            _projectRepository.SoftDelete(prId);
            _uow.Save();
        }


        public ProjectResponse CalculateProjectBudget(Guid prId)
        {

            var project = _projectRepository.Find(p => p.Id == prId).FirstOrDefault();
            var candidates = _projCandidateRepository.Find(pc => pc.ProjectId == prId, _projCandInclude)
                .ToList();

            var income = CalculateMonthlyIncome(candidates);
            var outcome = CalculateMonthlyOutcome(candidates);
            var profit = CalculateMonthlyProfit(income, outcome);

            project.MonthlyIncome = income;
            project.MonthlyOutcome = outcome;
            project.MonthlyProfit = profit;

            _projectRepository.Update(project);
            _uow.Save();

            return GetProjectById(prId);
        }

        public void SetProjectStatus(Guid prId, ProjectStatus status)
        {
            var prEntity = _projectRepository.Find(p => p.Id == prId).FirstOrDefault();

            _ = prEntity ?? throw new NotFoundException("Project was not found");

            prEntity.Status = status;
            _projectRepository.Update(prEntity);
            _uow.Save();
        }

        private static double CalculateMonthlyIncome(List<ProjectCandidate> candidates)
        {
            return (candidates.Sum(c => c.ExternalRate * (DailyHours * c.FTE) * AvarageNumbWorkDaysMonth));
        }

        private static double CalculateMonthlyOutcome(List<ProjectCandidate> candidates)
        {
            return (candidates.Sum(c => (c.InternalRate * (DailyHours * c.FTE) * AvarageNumbWorkDaysMonth)
                    + (MonthExpensPerEmployee * AvarageNumbWorkDaysMonth)));
        }

        private static double CalculateMonthlyProfit(double income, double outcome)
        {
            return Math.Round(((income - outcome) / income) * HundredPercent, RoundToHundreds);
        }

        private List<CandidateResponse> GetProjectCandidates(Guid prId)
        {
            return _projCandidateRepository.Find(pc => pc.ProjectId == prId, _projCandInclude)
                .Select(prEntity => _mapper.Map<CandidateResponse>(prEntity)).ToList();
        }

        private List<RiskResponse> GetProjectRisks(Guid prId)
        {
            return _projRiskRepository.Find(r => r.ProjectId == prId, _projRiskIncludes)
                .Select(empEntity => _mapper.Map<RiskResponse>(empEntity)).ToList();
        }

        private List<StakeholderResponse> GetProjectStakeholders(Guid prId)
        {
            return _projStakeholderRepository.Find(pr => pr.ProjectId == prId, _projStakIncludes)
                .Select(empEntity => _mapper.Map<StakeholderResponse>(empEntity)).ToList();
        }
    }
}
