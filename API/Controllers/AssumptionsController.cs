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
        private readonly IAssumptionsService _assumpService;

        public AssumptionsController(IAssumptionsService assumpService)
        {
            _assumpService = assumpService;
        }

        [HttpPost]
        public ActionResult<AssumptionResponse> AddAssumption(AssumptionRequest assumpRequest)
        {
            return Ok(_assumpService.AddAssumption(assumpRequest));
        }

        [HttpPut("{assumpId:Guid}")]
        public ActionResult<AssumptionResponse> UpdateAssumption(AssumptionRequest assumpRequest, Guid assumpId)
        {
            return Ok(_assumpService.UpdateAssumption(assumpRequest, assumpId));
        }

        [HttpDelete("{assumpId:Guid}")]
        public IActionResult DeleteAssumption(Guid assumpId)
        {
            _assumpService.DeleteAssumption(assumpId);

            return Ok();
        }
    }
}
