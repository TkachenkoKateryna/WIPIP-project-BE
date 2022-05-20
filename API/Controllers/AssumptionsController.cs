using API.Controllers.Base;
using Application.Interfaces;
using Application.Interfaces.Util;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AssumptionsController : BaseApiController
    {
        readonly IAssumptionsService _assumpService;

        public AssumptionsController(
            IAssumptionsService assumpService)
        {
            _assumpService = assumpService;
        }

        [HttpGet("assumptions")]
        public ActionResult<IEnumerable<AssumptionResponse>> GetAllAssumptions([FromQuery] string projId = null)
        {
            return Ok(_assumpService.GetAssumptions(projId));
        }

        [HttpPost("assumptions")]
        public ActionResult<AssumptionResponse> AddObjective(AssumptionRequest assumpRequest)
        {
            try
            {
                var assumpResp = _assumpService.AddAssumption(assumpRequest);
                return Ok(assumpResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("assumptions/{assumpId}")]
        public ActionResult<AssumptionResponse> UpdateAssumption(AssumptionRequest assumpRequest, string assumpId)
        {
            try
            {
                var assumpResp = _assumpService.UpdateAssumption(assumpRequest, assumpId);
                return Ok(assumpResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("assumptions/{assumpId}")]
        public IActionResult DeleteAssumption(string assumpId)
        {
            try
            {
                _assumpService.DeleteAssumption(assumpId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
