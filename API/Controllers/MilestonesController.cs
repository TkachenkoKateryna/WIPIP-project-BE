using Application.Interfaces;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MilestonesController : BaseApiController
    {
        readonly IMilestoneService _milService;

        public MilestonesController(IMilestoneService milService)
        {
            _milService = milService;
        }

        [HttpGet("milestonesByProject/{projId}")]
        public ActionResult<IEnumerable<MilestoneResponse>> GetAllMilestonesByProject(string projId)
        {
            return Ok(_milService.GetAllMilestonesByProject(projId));
        }

        [HttpGet("milestones")]
        public ActionResult<IEnumerable<MilestoneResponse>> GetAllMilestones()
        {
            return Ok(_milService.GetAllMilestones());
        }

        [HttpPut("milestones/add")]
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

        [HttpPut("milestones/update/{milId}")]
        public ActionResult<MilestoneResponse> UpdateMilestone(MilestoneRequest milRequest, string milId)
        {
            try
            {
                var milResp = _milService.UpdateMilestone(milRequest, milId);
                return Ok(milResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("milestones/delete/{milId}")]
        public IActionResult DeleteMilestone(string milId)
        {
            try
            {
                _milService.DeleteMilestone(milId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
