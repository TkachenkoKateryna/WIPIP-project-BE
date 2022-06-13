using API.Controllers.Base;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/milestones")]
    public class MilestonesController : ControllerBase
    {
        readonly IMilestoneService _milService;

        public MilestonesController(IMilestoneService milService)
        {
            _milService = milService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MilestoneResponse>> GetAllMilestones()
        {
            return Ok(_milService.GetAllMilestones());
        }

        [HttpPost]
        public ActionResult<MilestoneResponse> AddMilestone(MilestoneRequest milRequest)
        {
            try
            {
                var milResp = _milService.AddMilestone(milRequest);
                return Ok(milResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{milestoneId}")]
        public ActionResult<MilestoneResponse> UpdateMilestone(MilestoneRequest milRequest, string milestoneId)
        {
            try
            {
                var milResp = _milService.UpdateMilestone(milRequest, milestoneId);
                return Ok(milResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{milestoneId}")]
        public IActionResult DeleteMilestone(string milestoneId)
        {
            try
            {
                _milService.DeleteMilestone(milestoneId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
