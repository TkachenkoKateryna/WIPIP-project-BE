using Application.Interfaces;
using Domain.Dtos.Filters;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<EmployeeResponse>> GetAllEmployees([FromQuery] EmployeeFilteringParams param)
        {
            return Ok(_employeeService.GetAllEmployees(param));
        }

        [HttpPut("employees/add")]
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

        [HttpPut("employees/update/{empId}")]
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

        [Microsoft.AspNetCore.Mvc.HttpDelete("employees/delete/{empId}")]
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

        [Microsoft.AspNetCore.Mvc.HttpPut("employees/updateImage/{empId}")]
        public IActionResult UpdateEmployeeImage(IFormFile file, string empId)
        {
            try
            {
                return Ok(_employeeService.UpdateEmployeeImage(file, empId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
