using Domain.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>> _includes;

        public EmployeeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _includes = employees => employees.Include(e => e.EmployeeSkills).ThenInclude(es => es.Skill);
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var op = _uow.GetRepository<Employee>()
                .GetAll(_includes)
                .ToList();
            var res = op.Select(empEntity => _mapper.Map<EmployeeDto>(empEntity))
                .ToList();
            return res;
        }
    }
}
