using API.Controllers.Base;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/assumptions")]
    public class AssumptionsController : ControllerBase
    {
        readonly IAssumptionsService _assumpService;

        public AssumptionsController(
            IAssumptionsService assumpService)
        {
            _assumpService = assumpService;
        }

        [HttpPost]
        public ActionResult<AssumptionResponse> AddAssumption(AssumptionRequest assumpRequest)
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

        [HttpPut("{assumpId}")]
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

        [HttpDelete("{assumpId}")]
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
