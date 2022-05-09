using Application.Interfaces;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DeliverablesController : BaseApiController
    {
        readonly IDeliverablesService _delService;

        public DeliverablesController(IDeliverablesService delService)
        {
            _delService = delService;
        }

        [HttpGet("deliverablesByProject/{projId}")]
        public ActionResult<IEnumerable<DeliverableResponse>> GetAllDeliverablesByProject(string projId)
        {
            return Ok(_delService.GetAllDeliverablesByProject(projId));
        }

        [HttpGet("deliverables")]
        public ActionResult<IEnumerable<DeliverableResponse>> GetAllDeliverables()
        {
            return Ok(_delService.GetAllDeliverables());
        }

        [HttpPut("deliverables/add")]
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

        [HttpPut("deliverables/update/{delId}")]
        public ActionResult<ObjectiveResponse> UpdateObjective(DeliverableRequest delRequest, string delId)
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

        [HttpDelete("deliverables/delete/{delId}")]
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
