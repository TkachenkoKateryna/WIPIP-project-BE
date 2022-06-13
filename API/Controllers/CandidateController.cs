using Domain.Interfaces.Services;
using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("candidates")]
    public class CandidateController : ControllerBase
    {
        readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public ActionResult<CandidateResponse> AddCandidate(CandidateRequest candidateRequest)
        {
            try
            {
                var candidateResp = _candidateService.AddCandidate(candidateRequest);
                return Ok(candidateResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{candidateId}")]
        public ActionResult<CandidateResponse> UpdateCandidate(CandidateRequest candidateRequest, string candidateId)
        {
            var candidateResp = _candidateService.UpdateCandidate(candidateRequest, candidateId);

            return Ok(candidateResp);
        }

        [HttpDelete("{candidateId}")]
        public IActionResult DeleteCandidate(string candidateId)
        {
            _candidateService.DeleteCandidate(candidateId);
            return Ok();
        }

        [HttpGet("employees")]
        public ActionResult<EmployeeResponse> GetTeamMembers([FromQuery] string projectId)
        {
            var empResp = _candidateService.GetEmployeesForCandidates(projectId);

            return Ok(empResp);
        }

        [HttpPost("employees")]
        public ActionResult<CandidateResponse> UpdateEmployeeToCandidate(CandidateEmployeeRequest candRequest)
        {
            var candidateResp = _candidateService.UpdateEmployeeToCandidate(candRequest);

            return Ok(candidateResp);
        }
    }
}
