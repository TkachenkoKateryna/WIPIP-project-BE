using API.Controllers.Base;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class DeliverablesController : BaseApiController
    {
        readonly IDeliverablesService _delService;

        public DeliverablesController(
            IDeliverablesService delService)
        {
            _delService = delService;
        }

        [AllowAnonymous]
        [HttpGet("deliverables")]
        public ActionResult<IEnumerable<DeliverableResponse>> GetAllDeliverables([FromQuery] string projectId)
        {
            return Ok(_delService.GetDeliverablesByProject(projectId));
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
