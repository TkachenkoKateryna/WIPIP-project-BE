using API.Controllers.Base;
using Domain.Models.Constants;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.Dtos.Request;

namespace API.Controllers
{
    public class CandidateController : BaseApiController
    {
        readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost(Strings.CandidateRoute)]
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

        [HttpPut(Strings.CandidateRoute + "{candidateId}")]
        public ActionResult<CandidateResponse> UpdateCandidate(CandidateRequest candidateRequest, string candidateId)
        {
            try
            {
                var candidateResp = _candidateService.UpdateCandidate(candidateRequest, candidateId);
                return Ok(candidateResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Strings.CandidateRoute)]
        public ActionResult<CandidateResponse> UpdateEmployeeToCandidate(CandidateEmployeeRequest candRequest)
        {
            try
            {
                var candidateResp = _candidateService.UpdateEmployeeToCandidate(candRequest);
                return Ok(candidateResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(Strings.CandidateRoute + "{candidateId}")]
        public IActionResult DeleteCandidate(string candidateId)
        {
            try
            {
                _candidateService.DeleteCandidate(candidateId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
