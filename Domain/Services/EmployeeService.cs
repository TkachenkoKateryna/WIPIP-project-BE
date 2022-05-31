using Domain.Models.Exceptions;
using AutoMapper;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Models.Filters;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<ProjectCandidate> _candidateRepository;
        private readonly IRepository<EmployeeSkill> _employeeSkillRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private readonly Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>> _employeeIncludes;
        private readonly Func<IQueryable<ProjectCandidate>, IIncludableQueryable<ProjectCandidate, object>> _candidateIncludes;

        private readonly string containerName = "wipipresources";

        public EmployeeService(IUnitOfWork uow,
            IMapper mapper,
            IFileStorageService fileStorageService)
        {
            _uow = uow;
            _employeeRepository = _uow.GetRepository<Employee>();
            _candidateRepository = _uow.GetRepository<ProjectCandidate>();
            _employeeSkillRepository = _uow.GetRepository<EmployeeSkill>();
            _fileStorageService = fileStorageService;
            _mapper = mapper;
            _employeeIncludes = employees => employees
                .Include(e => e.EmployeeSkills).ThenInclude(es => es.Skill);
            _candidateIncludes = candidate => candidate
                .Include(c => c.Skill)
                .Include(c => c.Employee);
        }

        public IEnumerable<EmployeeResponse> GetAllEmployees(EmployeeFilteringParams param)
        {
            var employees = _employeeRepository
                .GetAll(_employeeIncludes).AsQueryable();

            if (!string.IsNullOrEmpty(param.SearchBy.Trim().ToLowerInvariant()))
            {
                employees = employees
                    .Where(e => e.Name.ToLower().Contains(param.SearchBy)
                                || e.Email.ToLower().Contains(param.SearchBy)
                                || e.Phone.ToLower().Contains(param.SearchBy));
            }

            if (param.MinEnglishLevel != null)
            {
                employees = employees.Where(emp => emp.EnglishLevel >= param.MinEnglishLevel);
            }

            if (param.SkillIds == null)
                return employees.Select(empEntity => _mapper.Map<EmployeeResponse>(empEntity))
                    .ToList();
            {
                var newList = employees.AsEnumerable().Where(emp => param.SkillIds.Any(sk =>
                    emp.EmployeeSkills.Any(empSk => empSk.SkillId == Guid.Parse(sk)))).ToList();

                return newList.Select(empEntity => _mapper.Map<EmployeeResponse>(empEntity));
            }
        }

        public EmployeeResponse AddEmployee(EmployeeRequest empRequest)
        {
            var empEntity = _employeeRepository
                .FindWithDeleted(emp => emp.Email == empRequest.Email)
                .FirstOrDefault();

            if (empEntity != null)
            {
                throw new AlreadyExistsException<Employee>(
                    $"Employee with {empRequest.Email} email already exists.");
            }

            empEntity = _mapper.Map<Employee>(empRequest);

            _employeeRepository.Create(empEntity);
            _uow.Save();

            return _mapper.Map<EmployeeResponse>(empEntity);
        }

        public EmployeeResponse UpdateEmployee(EmployeeRequest empRequest, string empId)
        {
            var empEntity = _employeeRepository.Find(emp => emp.Id == Guid.Parse(empId))
                .FirstOrDefault();

            _ = empEntity ?? throw new NotFoundException<Employee>($"Employee with id {empId} was not found.");

            RemoveEmployeeSkill(empId);

            empEntity = _mapper.Map<Employee>(empRequest);
            empEntity.Id = Guid.Parse(empId);

            _employeeRepository.Update(empEntity);

            AddEmployeeSkill(empRequest.EmployeeSkills, empId);

            _uow.Save();

            return _mapper.Map<EmployeeResponse>(_employeeRepository
                .Find(emp => emp.Id == empEntity.Id, _employeeIncludes).FirstOrDefault());
        }

        public void DeleteEmployee(string empId)
        {
            var empEntity = _employeeRepository.FindWithDeleted(emp => emp.Id.ToString() == empId)
                .FirstOrDefault();
            _ = empEntity ?? throw new NotFoundException<Employee>($"Employee with id {empId} was not found.");

            _employeeRepository.SoftDelete(Guid.Parse(empId));
            _uow.Save();
        }

        public IEnumerable<EmployeeResponse> GeneratePossibleTeamOptions(string projectId)
        {
            var candidates = _candidateRepository
                .Find(c => c.ProjectId == Guid.Parse(projectId), _candidateIncludes)
                .ToList();

            var teamMembers = new List<Guid>();

            foreach (var candidate in candidates)
            {
                var members = _employeeSkillRepository.Find(empSk =>
                    (empSk.SkillId == candidate.SkillId) &&
                    (empSk.Proficiency == candidate.Proficiency) &&
                    (empSk.Primary == true))
                    .Select(emp => emp.EmployeeId);

                teamMembers.AddRange(members);
            }

            return _employeeRepository.Find(emp => teamMembers.Contains(emp.Id), _employeeIncludes)
                .Select(empEntity => _mapper.Map<EmployeeResponse>(empEntity));
        }

        private void RemoveEmployeeSkill(string empId)
        {
            foreach (var employeeSkill in _employeeSkillRepository.Find(sk =>
                         sk.EmployeeId == Guid.Parse(empId)))
            {
                _employeeSkillRepository.Delete(employeeSkill);
            }
        }

        private void AddEmployeeSkill(IEnumerable<EmployeeSkillRequest> skills, string empId)
        {

            foreach (var skill in skills)
            {
                _employeeSkillRepository.Create(new EmployeeSkill()
                {
                    EmployeeId = Guid.Parse(empId),
                    SkillId = Guid.Parse(skill.SkillId),
                    Proficiency = skill.Proficiency,
                    Primary = skill.Primary

                });
            }
        }
    }
}
