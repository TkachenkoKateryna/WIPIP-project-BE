using API.Controllers.Base;
using Domain.Dtos.Filters;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        readonly IEmployeeService _employeeService;

        public EmployeeController(
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("employees")]
        public ActionResult<IEnumerable<EmployeeResponse>> GetAllEmployees([FromQuery] EmployeeFilteringParams param)
        {
            return Ok(_employeeService.GetAllEmployees(param));
        }

        [HttpPost("employees/add")]
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

        [HttpPut("employees/{empId}")]
        public ActionResult<EmployeeResponse> UpdateEmployee(EmployeeRequest empRequest, string empId)
        {
            try
            {
                var empResp = _employeeService.UpdateEmployee(empRequest, empId);
                return Ok(empResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("employees/{empId}")]
        public IActionResult DeleteEmployee(string empId)
        {
            try
            {
                _employeeService.DeleteEmployee(empId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("teamMembers")]
        public ActionResult<EmployeeResponse> GetTeamMembers([FromQuery] string projectId)
        {
            try
            {
                var empResp = _employeeService.GeneratePossibleTeamOptions(projectId);
                return Ok(empResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }
    }
}
