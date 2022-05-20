using Application.Interfaces;
using Application.Interfaces.Util;
using AutoMapper;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
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

        private readonly Func<IQueryable<Project>, IIncludableQueryable<Project, object>> _projIncludes;
        private readonly Func<IQueryable<ProjectStakeholder>, IIncludableQueryable<ProjectStakeholder, object>> _projStakIncludes;
        private readonly Func<IQueryable<ProjectRisk>, IIncludableQueryable<ProjectRisk, object>> _projRiskIncludes;
        private readonly Func<IQueryable<ProjectCandidate>, IIncludableQueryable<ProjectCandidate, object>> _projCandInclude;

        public ProjectService(IUnitOfWork uow, IMapper mapper, IPDFService pdfService)
        {
            _uow = uow;
            _projectRepository = _uow.GetRepository<Project>();
            _projRiskRepository = _uow.GetRepository<ProjectRisk>();
            _projCandidateRepository = _uow.GetRepository<ProjectCandidate>();
            _projStakeholderRepository = _uow.GetRepository<ProjectStakeholder>();
            _mapper = mapper;
            _pdfService = pdfService;
            _projIncludes = project => project
                .Include(p => p.Objectives)
                .Include(p => p.Assumptions)
                .Include(P => P.Deliverables)
                .Include(p => p.Milestones).ThenInclude(m => m.Deliverables)
                .Include(p => p.ProjectStakeholders).ThenInclude(st => st.Stakeholder);
            _projRiskIncludes = risk => risk
                .Include(r => r.Risk);
            _projStakIncludes = stak => stak
                .Include(st => st.Stakeholder);
            _projCandInclude = cand => cand
                .Include(c => c.Skill)
                .Include(c => c.Employee);
        }

        public ProjectResponse GetProjectById(string projId)
        {
            var project = _projectRepository
                .Find(p => p.Id == Guid.Parse(projId), _projIncludes)
                .Select(empEntity => _mapper.Map<ProjectResponse>(empEntity))
                .FirstOrDefault();

            project.Stakeholders = _projStakeholderRepository
                .Find(p => p.ProjectId == Guid.Parse(projId), _projStakIncludes)
                .Select(empEntity => _mapper.Map<StakeholderResponse>(empEntity))
                .ToList();

            project.Risks = _projRiskRepository
                .Find(r => r.ProjectId == Guid.Parse(projId), _projRiskIncludes)
                .Select(empEntity => _mapper.Map<RiskResponse>(empEntity))
                .ToList();


            project.Candidates = _projCandidateRepository
                .Find(r => r.ProjectId == Guid.Parse(projId), _projCandInclude)
                .Select(empEntity => _mapper.Map<ProjectCandidateResponse>(empEntity))
                .ToList();

            return project;
        }

        public ProjectBudgetResponse CalculateProjectBudget(string projectId)
        {

            var projectBudget = new ProjectBudgetResponse();
            var candidates = _projCandidateRepository
                .Find(pc => pc.ProjectId == Guid.Parse(projectId), _projCandInclude)
                .Select(projectEntity => _mapper.Map<ProjectCandidateResponse>(projectEntity))
                .ToList();

            projectBudget.MonthlyIncome = (candidates.Sum(c => c.ExternalRate * (8 * c.FTE) * 21));
            projectBudget.MonthlyOutcome = (candidates.Sum(c => (c.InternalRate * (8 * c.FTE) * 21) + (6 * 21)));
            projectBudget.MonthlyProfit =
                Math.Round(
                    ((projectBudget.MonthlyIncome - projectBudget.MonthlyOutcome)
                     / projectBudget.MonthlyIncome)
                     * 100, 2);

            return projectBudget;
        }
    }
}
