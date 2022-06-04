using Domain.Models.Exceptions;
using AutoMapper;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Models.Constants;
using Domain.Models.Dtos.Request;

namespace Domain.Services
{
    public class RiskService : IRiskService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Risk> _riskRepository;
        private readonly IRepository<RiskCategory> _riskCategoryRepository;
        private readonly IRepository<ProjectRisk> _projRiskRepository;
        private readonly Func<IQueryable<Risk>, IIncludableQueryable<Risk, object>> _includes;
        private readonly Func<IQueryable<ProjectRisk>, IIncludableQueryable<ProjectRisk, object>> _projRiskIncludes;
        private readonly Func<IQueryable<Project>, IIncludableQueryable<Project, object>> _projIncludes;
        private readonly Func<IQueryable<ProjectStakeholder>, IIncludableQueryable<ProjectStakeholder, object>> _projStakIncludes;
        private readonly Func<IQueryable<ProjectCandidate>, IIncludableQueryable<ProjectCandidate, object>> _projCandInclude;


        public RiskService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _riskRepository = _uow.GetRepository<Risk>();
            _projRiskRepository = _uow.GetRepository<ProjectRisk>();
            _riskCategoryRepository = _uow.GetRepository<RiskCategory>();
            _mapper = mapper;
            _includes = risk => risk
                .Include(r => r.RiskCategory)
                .Include(r => r.ProjectRisks).ThenInclude(pr => pr.Project);
            _projRiskIncludes = projectRisk => projectRisk
                .Include(pr => pr.Risk).ThenInclude(r => r.RiskCategory);
            _projIncludes = project => project
                .Include(p => p.Objectives)
                .Include(p => p.Assumptions)
                .Include(p => p.Deliverables)
                .Include(p => p.Manager)
                .Include(p => p.Milestones).ThenInclude(m => m.Deliverables)
                .Include(p => p.ProjectStakeholders).ThenInclude(st => st.Stakeholder);
            _projStakIncludes = stak => stak
                .Include(st => st.Stakeholder);
            _projCandInclude = cand => cand
                .Include(c => c.Skill)
                .Include(c => c.Employee);
        }

        public IEnumerable<RiskResponse> GetAllRisks()
        {
            return _riskRepository
                .GetAllWithDeleted(_includes)
                .Select(entity => _mapper.Map<RiskResponse>(entity))
                .ToList();
        }

        public IEnumerable<RiskResponse> GetRisksByProject(string projectId)
        {
            return _projRiskRepository
                .Find(risk => risk.ProjectId == Guid.Parse(projectId), _projRiskIncludes)
                .Select(entity => _mapper.Map<RiskResponse>(entity))
                .ToList();
        }

        public RiskResponse AddRisk(RiskRequest riskRequest)
        {
            var riskEntity = _riskRepository
                .FindWithDeleted(r => r.Title == riskRequest.Title)
                .FirstOrDefault();

            if (riskEntity != null)
            {
                throw new AlreadyExistsException<Objective>(
                    $"Risk with such {riskRequest.Title} already exists.");
            }

            riskEntity = _mapper.Map<Risk>(riskRequest);

            var id = _riskRepository.CreateWithVal(riskEntity);

            if (riskRequest.ProjectId != null)
            {
                _projRiskRepository.Create(new ProjectRisk()
                {
                    ProjectId = Guid.Parse(riskRequest.ProjectId),
                    RiskId = riskEntity.Id
                });

            }
            _uow.Save();

            return _mapper.Map<RiskResponse>(_riskRepository
                .Find(risk => risk.Id == id, _includes)
                .FirstOrDefault());
            ;
        }

        public RiskResponse UpdateRisk(RiskRequest riskRequest, string riskId)
        {
            var riskEntity = _riskRepository
                .Find(risk => risk.Id.ToString() == riskId)
                .FirstOrDefault();
            _ = riskEntity ?? throw new NotFoundException<Risk>(
                $"Risk with id {riskId} was not found.");

            riskEntity = _mapper.Map<Risk>(riskRequest);
            riskEntity.Id = Guid.Parse(riskId);
            _riskRepository.Update(riskEntity);
            _uow.Save();

            var res = _mapper.Map<RiskResponse>(_riskRepository
                .Find(ob => ob.Id.ToString() == riskId, _includes)
                .FirstOrDefault());

            return res;
        }

        public void DeleteRisk(string riskId)
        {
            var riskEntity = _riskRepository
                .FindWithDeleted(risk => risk.Id.ToString() == riskId)
                .FirstOrDefault();
            _ = riskEntity ?? throw new NotFoundException<Risk>(
                $"Risk with id {riskId} was not found.");

            _riskRepository.SoftDelete(Guid.Parse(riskId));

            _uow.Save();
        }

        public void RemoveRiskFromProject(RiskProjectRequest projectRiskRequest)
        {
            var projectRiskEntity = _projRiskRepository
                .Find(r => r.RiskId == Guid.Parse(projectRiskRequest.RiskId) && r.ProjectId == Guid.Parse(projectRiskRequest.ProjectId))
                .FirstOrDefault();

            _ = projectRiskEntity ?? throw new NotFoundException<Risk>(
                $"Risk with id {projectRiskRequest.RiskId} was not found.");

            _projRiskRepository.Delete(projectRiskEntity);
            _uow.Save();
        }

        public RiskResponse AssignRiskToProject(RiskProjectRequest projectRiskRequest)
        {
            var projectRiskEntity = _projRiskRepository
                .Find(r => r.RiskId == Guid.Parse(projectRiskRequest.RiskId) && r.ProjectId == Guid.Parse(projectRiskRequest.ProjectId))
                .FirstOrDefault();

            if (projectRiskEntity != null)
            {
                throw new AlreadyExistsException<ProjectRisk>("Such project risk already exists");
            }

            projectRiskEntity = new ProjectRisk()
            {
                ProjectId = Guid.Parse(projectRiskRequest.ProjectId),
                RiskId = Guid.Parse(projectRiskRequest.RiskId)
            };

            var id = _projRiskRepository.CreateWithVal(projectRiskEntity);
            _uow.Save();

            return _mapper.Map<RiskResponse>(_riskRepository
                .Find(r => r.Id == id, _includes)
                .FirstOrDefault());
        }

        public IEnumerable<RiskCategoryResponse> GetRiskCategories()
        {
            return _riskCategoryRepository
                .GetAll()
                .Select(r => _mapper.Map<RiskCategoryResponse>(r))
                .ToList();
        }

        public IEnumerable<RiskResponse> GenerateRisks(string projectId)
        {
            var risks = new List<Risk>();

            var project = _uow.GetRepository<Project>()
                .Find(p => p.Id == Guid.Parse(projectId), _projIncludes)
                .FirstOrDefault();

            project.Candidates = _uow.GetRepository<ProjectCandidate>()
                .Find(pc => pc.ProjectId == Guid.Parse(projectId), _projCandInclude)
                .ToList();

            if (project == null)
            {
                throw new NotFoundException<Project>($"Project with id {projectId} wasn't found");
            }

            if (!project.Assumptions.Any())
            {
                risks.AddRange(_riskRepository.Find(risk => risk.RiskCategory.Title == "Assumptions Risks"));
            }

            if (!project.Objectives.Any())
            {
                risks.AddRange(_riskRepository.Find(risk => risk.RiskCategory.Title == "Project goals Risks"));
            }

            if (project.Candidates.Any(c => c.EmployeeId == null))
            {
                risks.AddRange(_riskRepository.Find(risk => risk.RiskCategory.Title == "Resource Risks"));
            }

            if (project.ProjectStakeholders.Any(c => c.Stakeholder.Payment == Payment.BigDelay ||
            c.Stakeholder.Payment == Payment.BigDelay))
            {
                risks.AddRange(_riskRepository.Find(risk => risk.RiskCategory.Title == "Payment Risks"));
            }
            if (project.ProjectStakeholders.Any(c => c.Stakeholder.CommunicationChannel == null))
            {
                risks.AddRange(_riskRepository.Find(risk => risk.RiskCategory.Title == "Communication Risks"));
            }

            if (project.Deliverables.Any())
            {
                risks.AddRange(_riskRepository.Find(risk => risk.RiskCategory.Title == "Scope Risks"));
            }

            if (project.MonthlyProfit < (double)44)
            {
                risks.AddRange(_riskRepository.Find(risk => risk.RiskCategory.Title == "Budget Risks"));
            }

            return risks.Select(r => _mapper.Map<RiskResponse>(r));
        }
    }
}
