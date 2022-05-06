using Application.Interfaces;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AssumptionsController : BaseApiController
    {
        readonly IAssumptionsService _assumpService;

        public AssumptionsController(IAssumptionsService assumpService)
        {
            _assumpService = assumpService;
        }

        [HttpGet("assumptionsByProject/{projId}")]
        public ActionResult<IEnumerable<AssumptionResponse>> GetAllAssumptionsByProject(string projId)
        {
            return Ok(_assumpService.GetAllAssumptionsByProject(projId));
        }

        [HttpGet("assumptions")]
        public ActionResult<IEnumerable<AssumptionResponse>> GetAllAssumptions()
        {
            return Ok(_assumpService.GetAllAssumptions());
        }

        [HttpPut("assumptions/add")]
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

        [HttpPut("assumptions/update/{assumpId}")]
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

        [HttpDelete("assumptions/delete/{assumpId}")]
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
