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
    public class RiskService : IRiskService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Risk> _riskRepository;
        private readonly IRepository<ProjectRisk> _projRiskRepository;
        private readonly Func<IQueryable<Risk>, IIncludableQueryable<Risk, object>> _includes;

        public RiskService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _riskRepository = _uow.GetRepository<Risk>();
            _projRiskRepository = _uow.GetRepository<ProjectRisk>();
            _mapper = mapper;
            _includes = risk => risk.Include(r => r.RiskCategory)
                .Include(r => r.ProjectRisks).ThenInclude(pr => pr.Project);
        }

        public IEnumerable<RiskResponse> GetAllRisksByProject(string projectId)
        {
            return _projRiskRepository.Find(r => r.ProjectId == Guid.Parse(projectId))
                .Select(entity => _mapper.Map<RiskResponse>(entity))
                .ToList();
        }

        public IEnumerable<RiskResponse> GetAllRisks()
        {
            return _riskRepository.GetAllWithDeleted(_includes)
                .Select(entity => _mapper.Map<RiskResponse>(entity))
                .ToList();
        }

        public RiskResponse AddRisk(RiskRequest riskRequest)
        {
            var riskEntity = _riskRepository.FindWithDeleted(r => r.Title == riskRequest.Title)
                .FirstOrDefault();

            if (riskEntity != null)
            {
                throw new AlreadyExistsException<Objective>($"Risk with such {riskRequest.Title} already exists.");
            }

            riskEntity = _mapper.Map<Risk>(riskRequest);

            _riskRepository.Create(riskEntity);

            _projRiskRepository.Create(new ProjectRisk()
            {
                ProjectId = Guid.Parse(riskRequest.ProjectId),
                RiskId = riskEntity.Id
            });

            _uow.Save();

            return _mapper.Map<RiskResponse>(_riskRepository
                .Find(r => r.Id == riskEntity.Id).FirstOrDefault());
        }

        public RiskResponse UpdateRisk(RiskRequest riskRequest, string riskId)
        {
            var riskEntity = _riskRepository.Find(ob => ob.Id.ToString() == riskId)
                .FirstOrDefault();
            _ = riskEntity ?? throw new NotFoundException<Objective>("Objective with id was not found.");

            riskEntity = _mapper.Map<Risk>(riskRequest);
            riskEntity.Id = Guid.Parse(riskId);
            _riskRepository.Update(riskEntity);
            _uow.Save();

            return _mapper.Map<RiskResponse>(_riskRepository.Find(ob => ob.Id.ToString() == riskId).FirstOrDefault());
        }

        public void DeleteRisk(string riskId)
        {
            var riskEntity = _riskRepository.FindWithDeleted(obj => obj.Id.ToString() == riskId)
                .FirstOrDefault();
            _ = riskEntity ?? throw new NotFoundException<Objective>($"Risk with id {riskId} was not found.");

            _riskRepository.SoftDelete(Guid.Parse(riskId));
            _uow.Save();
        }
    }
}
