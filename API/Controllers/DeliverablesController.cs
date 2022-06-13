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
        readonly IDeliverablesService _delService;

        public DeliverablesController(IDeliverablesService delService)
        {
            _delService = delService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeliverableResponse>> GetAllDeliverables([FromQuery] string projectId)
        {
            return Ok(_delService.GetDeliverablesByProject(projectId));
        }

        [HttpPost]
        public ActionResult<DeliverableResponse> AddDeliverable(DeliverableRequest delRequest)
        {
            try
            {
                var delResp = _delService.AddDeliverable(delRequest);
                return Ok(delResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{delId}")]
        public ActionResult<DeliverableResponse> UpdateDeliverable(DeliverableRequest delRequest, string delId)
        {
            try
            {
                var delResp = _delService.UpdateDeliverable(delRequest, delId);
                return Ok(delResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{delId}")]
        public IActionResult DeleteDeliverables(string delId)
        {
            try
            {
                _delService.DeleteDeliverable(delId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
