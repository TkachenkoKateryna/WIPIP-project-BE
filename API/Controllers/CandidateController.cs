using Domain.Interfaces.Services;
using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidateController : ControllerBase
    {
        readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet("employees")]
        public ActionResult<EmployeeResponse> GetTeamMembers([FromQuery] Guid projectId)
        {
            return Ok(_candidateService.GetEmployeesForCandidates(projectId));
        }

        [HttpPost]
        public ActionResult<CandidateResponse> AddCandidate(CandidateRequest candidateRequest)
        {
            return Ok(_candidateService.AddCandidate(candidateRequest));
        }

        [HttpPost("employees")]
        public ActionResult<CandidateResponse> UpdateEmployeeToCandidate(CandidateEmployeeRequest candRequest)
        {
            return Ok(_candidateService.UpdateEmployeeToCandidate(candRequest));
        }

        [HttpPut("{candidateId:Guid}")]
        public ActionResult<CandidateResponse> UpdateCandidate(CandidateRequest candidateRequest, Guid candidateId)
        {
            return Ok(_candidateService.UpdateCandidate(candidateRequest, candidateId));
        }

        [HttpDelete("{candidateId:Guid}")]
        public IActionResult DeleteCandidate(Guid candidateId)
        {
            _candidateService.DeleteCandidate(candidateId);

            return Ok();
        }
    }
}
