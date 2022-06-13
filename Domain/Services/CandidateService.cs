using Domain.Models.Exceptions;
using AutoMapper;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Models.Dtos.Request;

namespace Domain.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<ProjectCandidate> _candidateRepository;
        private readonly Func<IQueryable<ProjectCandidate>, IIncludableQueryable<ProjectCandidate, object>> _includes;
        private readonly Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>> _employeeIncludes;

        public CandidateService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _candidateRepository = _uow.GetRepository<ProjectCandidate>();
            _mapper = mapper;
            _includes = candidate => candidate
                .Include(c => c.Project)
                .Include(c => c.Employee)
                .Include(c => c.Skill);
            _employeeIncludes = employee => employee
                 .Include(e => e.EmployeeSkills).ThenInclude(es => es.Skill);
        }

        public CandidateResponse AddCandidate(CandidateRequest candRequest)
        {
            var candEntity = _mapper.Map<ProjectCandidate>(candRequest);
            var id = _candidateRepository.CreateWithVal(candEntity);
            _uow.Save();

            return _mapper.Map<CandidateResponse>(_candidateRepository
                    .Find(cand => cand.Id == id, _includes)
                    .FirstOrDefault());
        }

        public CandidateResponse UpdateCandidate(CandidateRequest candidateRequest, string candId)
        {
            var candEntity = _candidateRepository
                .Find(cand => cand.Id == Guid.Parse(candId), _includes)
                .FirstOrDefault();

            _ = candEntity ?? throw new NotFoundException<ProjectCandidate>
                ($"Candidate with id: {candId} was not found.");

            candEntity = _mapper.Map<ProjectCandidate>(candidateRequest);
            candEntity.Id = Guid.Parse(candId);

            _candidateRepository.Update(candEntity);
            _uow.Save();

            return _mapper.Map<CandidateResponse>(_candidateRepository
                .Find(cand => cand.Id == candEntity.Id, _includes)
                .FirstOrDefault());
        }

        public void DeleteCandidate(string candidateId)
        {
            var candidateEntity = _candidateRepository
                .Find(mil => mil.Id.ToString() == candidateId)
                .FirstOrDefault();

            _ = candidateEntity ?? throw new NotFoundException<ProjectCandidate>
                ($"Candidate with id: {candidateId} was not found.");

            _candidateRepository.Delete(candidateEntity);

            _uow.Save();
        }

        public IEnumerable<EmployeeResponse> GetEmployeesForCandidates(string projectId)
        {
            var candidates = _candidateRepository
                .Find(c => c.ProjectId == Guid.Parse(projectId), _includes)
                .ToList();

            var employees = new List<Guid>();

            foreach (var candidate in candidates)
            {
                var members = _uow.GetRepository<EmployeeSkill>()
                    .Find(empSk => (empSk.SkillId == candidate.SkillId) && (empSk.Proficiency == candidate.Proficiency) &&
                    (empSk.Primary == true))
                    .Select(emp => emp.EmployeeId);

                employees.AddRange(members);
            }

            return _uow.GetRepository<Employee>().Find(emp => employees.Contains(emp.Id), _employeeIncludes)
                .Select(empEntity => _mapper.Map<EmployeeResponse>(empEntity));
        }


        public CandidateResponse UpdateEmployeeToCandidate(CandidateEmployeeRequest candidateRequest)
        {
            var candEntity = _candidateRepository
                .Find(cand => cand.Id == Guid.Parse(candidateRequest.CandidateId), _includes)
                .FirstOrDefault();

            if (candEntity == null)
            {
                throw new NotFoundException<ProjectCandidate>("Such candidate wasn't found");
            }

            var candEntityWithEmployee = _candidateRepository
                .Find(cand => cand.EmployeeId == Guid.Parse(candidateRequest.EmployeeId)
                && cand.ProjectId == Guid.Parse(candidateRequest.EmployeeId))
                .FirstOrDefault();

            if (!candidateRequest.ToRemove)
            {
                candEntity.EmployeeId = Guid.Parse(candidateRequest.EmployeeId);
            }
            else
            {
                candEntity.EmployeeId = null;
            }
            _candidateRepository.Update(candEntity);
            _uow.Save();

            return _mapper.Map<CandidateResponse>(_candidateRepository
                .Find(cand => cand.Id == candEntity.Id, _includes)
                .FirstOrDefault());
        }

    }
}
