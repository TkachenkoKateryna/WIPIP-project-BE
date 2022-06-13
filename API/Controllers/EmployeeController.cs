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
            return Ok(_employeeService.GetAllEmployees(param));
        }

        [HttpPost]
        public ActionResult<EmployeeResponse> AddEmployee(EmployeeRequest empRequest)
        {
            try
            {
                var empResp = _employeeService.AddEmployee(empRequest);
                return Ok(empResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{employeeId}")]
        public ActionResult<EmployeeResponse> UpdateEmployee(EmployeeRequest empRequest, string employeeId)
        {
            try
            {
                var empResp = _employeeService.UpdateEmployee(empRequest, employeeId);
                return Ok(empResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(string employeeId)
        {
            try
            {
                _employeeService.DeleteEmployee(employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
