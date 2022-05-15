using Application.Exceptions;
using Domain.Dtos;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.Internal;
using Domain.Constants;
using Domain.Dtos.Filters;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeSkill> _employeeSkillRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private readonly Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>> _includes;

        private readonly string containerName = "wipipresources";

        public EmployeeService(IUnitOfWork uow, IMapper mapper, IFileStorageService fileStorageService)
        {
            _uow = uow;
            _employeeRepository = _uow.GetRepository<Employee>();
            _employeeSkillRepository = _uow.GetRepository<EmployeeSkill>();
            _fileStorageService = fileStorageService;
            _mapper = mapper;
            _includes = employees => employees.Include(e => e.EmployeeSkills).ThenInclude(es => es.Skill);
        }

        public IEnumerable<EmployeeResponse> GetAllEmployees(EmployeeFilteringParams param)
        {
            var employees = _employeeRepository
                .GetAll(_includes).AsQueryable();

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
                .Find(emp => emp.Id == empEntity.Id, _includes).FirstOrDefault());
        }

        public void DeleteEmployee(string empId)
        {
            var empEntity = _employeeRepository.FindWithDeleted(emp => emp.Id.ToString() == empId)
                .FirstOrDefault();
            _ = empEntity ?? throw new NotFoundException<Employee>($"Employee with id {empId} was not found.");

            _employeeRepository.SoftDelete(Guid.Parse(empId));
            _uow.Save();
        }

        public string UpdateEmployeeImage(IFormFile image, string empId)
        {
            var empEntity = _employeeRepository.FindWithDeleted(emp => emp.Id.ToString() == empId)
                .FirstOrDefault();
            _ = empEntity ?? throw new NotFoundException<Employee>($"Employee with id {empId} was not found.");

            if (image != null)
            {
                using var memoryStream = new MemoryStream();
                image.CopyTo(memoryStream);
                var content = memoryStream.ToArray();
                var extension = Path.GetExtension(image.FileName);
                empEntity.ImageLink = _fileStorageService
                    .SaveFile(content, extension, containerName, image.ContentType);
            }
            else
            {
                empEntity.ImageLink = null;
            }

            _employeeRepository.Update(empEntity);
            _uow.Save();

            return empEntity.ImageLink;
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
