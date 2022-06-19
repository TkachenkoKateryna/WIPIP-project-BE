using Domain.Interfaces.Services;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/deliverables")]
    public class DeliverablesController : ControllerBase
    {
        private readonly IDeliverablesService _delService;

        public DeliverablesController(IDeliverablesService delService)
        {
            _delService = delService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeliverableResponse>> GetAllDeliverables([FromQuery] Guid projectId)
        {
            return Ok(_delService.GetDeliverablesByProject(projectId));
        }

        [HttpPost]
        public ActionResult<DeliverableResponse> AddDeliverable(DeliverableRequest delRequest)
        {
            return Ok(_delService.AddDeliverable(delRequest));
        }

        [HttpPut("{delId:Guid}")]
        public ActionResult<DeliverableResponse> UpdateDeliverable(DeliverableRequest delRequest, Guid delId)
        {
            return Ok(_delService.UpdateDeliverable(delRequest, delId));
        }

        [HttpDelete("{delId:Guid}")]
        public IActionResult DeleteDeliverables(Guid delId)
        {
            _delService.DeleteDeliverable(delId);

            return Ok();
        }
    }
}
