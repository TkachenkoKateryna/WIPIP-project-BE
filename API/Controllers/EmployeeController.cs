using Domain.Models.Filters;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeResponse>> GetAllEmployees([FromQuery] EmployeeFilteringParams param)
        {
            return Ok(_employeeService.GetEmployees(param));
        }

        [HttpPost]
        public ActionResult<EmployeeResponse> AddEmployee(EmployeeRequest empRequest)
        {
            return Ok(_employeeService.AddEmployee(empRequest));
        }

        [HttpPut("{employeeId:Guid}")]
        public ActionResult<EmployeeResponse> UpdateEmployee(EmployeeRequest empRequest, Guid employeeId)
        {
            return Ok(_employeeService.UpdateEmployee(empRequest, employeeId));
        }

        [HttpDelete("{employeeId:Guid}")]
        public IActionResult DeleteEmployee(Guid employeeId)
        {
            _employeeService.DeleteEmployee(employeeId);

            return Ok();
        }
    }
}
