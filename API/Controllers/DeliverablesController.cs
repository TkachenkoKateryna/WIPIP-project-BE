using API.Controllers.Base;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DeliverablesController : BaseApiController
    {
        readonly IDeliverablesService _delService;

        public DeliverablesController(
            IDeliverablesService delService)
        {
            _delService = delService;
        }

        [HttpGet("deliverables")]
        public ActionResult<IEnumerable<DeliverableResponse>> GetAllDeliverables()
        {
            return Ok(_delService.GetAllDeliverables());
        }

        [HttpPost("deliverables")]
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

        [HttpPut("deliverables/{delId}")]
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

        [HttpDelete("deliverables/{delId}")]
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
