using API.Controllers.Base;
using Application.Interfaces;
using Application.Interfaces.Util;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CandidateController : BaseApiController
    {
        readonly ICandidateService _candidateService;

        public CandidateController(
            ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet("candidates")]
        public ActionResult<IEnumerable<ProjectCandidateResponse>> GetAllRisks()
        {
            return Ok(_candidateService.GetCandidates());
        }

        [HttpPost("candidates")]
        public ActionResult<ProjectCandidateResponse> AddObjective(ProjectCandidateRequest candidateRequest)
        {
            try
            {
                var candResp = _candidateService.AddCandidate(candidateRequest);
                return Ok(candResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("candidates/{candId}")]
        public ActionResult<ProjectCandidateResponse> UpdateRisk(ProjectCandidateRequest candRequest, string candId)
        {
            try
            {
                var candResp = _candidateService.UpdateCandidate(candRequest, candId);
                return Ok(candResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("candidates/{candId}")]
        public IActionResult DeleteCandidate(string candId)
        {
            try
            {
                _candidateService.DeleteCandidate(candId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
