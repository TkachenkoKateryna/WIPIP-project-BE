using Domain.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("employees")]
        public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }
    }
}
