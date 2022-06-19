using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Constants;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

        public IEnumerable<RiskResponse> GetRisks()
        {
            return _riskRepository.GetAll(_includes).Select(rEntity => _mapper.Map<RiskResponse>(rEntity))
                .ToList();
        }

        public IEnumerable<RiskResponse> GetRisksByProject(Guid prId)
        {
            return _projRiskRepository.Find(r => r.ProjectId == prId, _projRiskIncludes)
                .Select(rEntity => _mapper.Map<RiskResponse>(rEntity)).ToList();
        }

        public RiskResponse AddRisk(RiskRequest rRequest)
        {
            var rEntity = _riskRepository.FindWithDeleted(r => r.Title == rRequest.Title).FirstOrDefault();

            if (rEntity != null)
            {
                throw new AlreadyExistsException("Risk with such title already exists", "title");
            }

            rEntity = _mapper.Map<Risk>(rRequest);

            var rId = _riskRepository.CreateWithVal(rEntity);

            if (rRequest.ProjectId != null)
            {
                _projRiskRepository.Create(new ProjectRisk()
                {
                    ProjectId = rRequest.ProjectId.Value,
                    RiskId = rId
                });
            }
            _uow.Save();

            return _mapper.Map<RiskResponse>(_riskRepository.Find(risk => risk.Id == rId, _includes)
                .FirstOrDefault());
            ;
        }

        public RiskResponse UpdateRisk(RiskRequest rRequest, Guid rId)
        {
            var rEntity = _riskRepository.Find(r => r.Id == rId).FirstOrDefault();

            _ = rEntity ?? throw new NotFoundException("Risk was not found");

            rEntity = _mapper.Map<Risk>(rRequest);
            rEntity.Id = rId;
            _riskRepository.Update(rEntity);
            _uow.Save();

            return _mapper.Map<RiskResponse>(_riskRepository.Find(r => r.Id == rId, _includes)
                .FirstOrDefault());
        }

        public void DeleteRisk(Guid rId)
        {
            var rEntity = _riskRepository.FindWithDeleted(r => r.Id == rId).FirstOrDefault();

            _ = rEntity ?? throw new NotFoundException("Risk was not found");

            _riskRepository.SoftDelete(rId);
            _uow.Save();
        }

        public RiskResponse RemoveRiskFromProject(Guid prId, Guid rId)
        {
            var prREntity = _projRiskRepository.Find(r => r.RiskId == rId && r.ProjectId == prId)
                .FirstOrDefault();

            _ = prREntity ?? throw new NotFoundException($"Risk was not found");

            _projRiskRepository.Delete(prREntity);
            _uow.Save();

            return _mapper.Map<RiskResponse>(_riskRepository.Find(r => r.Id == rId, _includes)
                .FirstOrDefault());
        }

        public RiskResponse AssignRiskToProject(Guid prId, Guid rId)
        {
            var prREntity = _projRiskRepository.Find(r => r.RiskId == rId && r.ProjectId == prId)
                .FirstOrDefault();

            if (prREntity != null)
            {
                throw new AlreadyExistsException("Such project risk already exists");
            }

            prREntity = new ProjectRisk()
            {
                ProjectId = prId,
                RiskId = rId
            };

            var id = _projRiskRepository.CreateWithVal(prREntity);
            _uow.Save();

            return _mapper.Map<RiskResponse>(_riskRepository.Find(r => r.Id == rId, _includes)
                .FirstOrDefault());
        }
        public IEnumerable<RiskResponse> GenerateRisks(Guid prId)
        {
            var risks = new List<Risk>();

            var project = _uow.GetRepository<Project>().Find(p => p.Id == prId, _projIncludes)
                .FirstOrDefault();

            project.Candidates = _uow.GetRepository<ProjectCandidate>()
                .Find(pc => pc.ProjectId == prId, _projCandInclude)
                .ToList();

            project.ProjectStakeholders = _uow.GetRepository<ProjectStakeholder>()
                .Find(p => p.ProjectId == prId, _projStakIncludes)
                .ToList();

            if (project == null)
            {
                throw new NotFoundException("Project was not found");
            }

            var riskIds = _projRiskRepository.Find(r => r.ProjectId == prId, _projRiskIncludes)
                .Select(risk => risk.RiskId).ToList();

            var risksResponse = _riskRepository.Find(risk => !riskIds.Any(r => r == risk.Id), _includes)
                .ToList();

            if (!project.Assumptions.Any())
            {
                risks.AddRange(risksResponse.Where(risk => risk.RiskCategory.Title == Strings.AssumptionCategory));
            }

            if (!project.Objectives.Any())
            {
                risks.AddRange(risksResponse.Where(risk => risk.RiskCategory.Title == Strings.ProjectGoalsCategory));
            }

            if (project.Candidates.Any(c => c.EmployeeId == null))
            {
                risks.AddRange(risksResponse.Where(risk => risk.RiskCategory.Title == Strings.ResourceCategory));
            }

            if (project.ProjectStakeholders.Any(c => c.Stakeholder.Payment == Payment.BigDelay || c.Stakeholder.Payment == Payment.BigDelay))
            {
                risks.AddRange(risksResponse.Where(risk => risk.RiskCategory.Title == Strings.PaymentCategory));
            }

            if (project.ProjectStakeholders.Any(c => c.Stakeholder.CommunicationChannel == null))
            {
                risks.AddRange(risksResponse.Where(risk => risk.RiskCategory.Title == Strings.CommunicationCategory));
            }

            if (project.Deliverables.Any())
            {
                risks.AddRange(risksResponse.Where(risk => risk.RiskCategory.Title == Strings.ScopeCategory));
            }

            if (project.MonthlyProfit < (double)44)
            {
                risks.AddRange(risksResponse.Where(risk => risk.RiskCategory.Title == Strings.BudgetCategory));
            }

            return risks.Select(r => _mapper.Map<RiskResponse>(r));
        }
    }
}
