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

        [HttpPost]
        public ActionResult<MilestoneResponse> AddMilestone(MilestoneRequest milRequest)
        {
            return Ok(_milService.AddMilestone(milRequest));
        }

        [HttpPut("{milestoneId:Guid}")]
        public ActionResult<MilestoneResponse> UpdateMilestone(MilestoneRequest milRequest, Guid milestoneId)
        {
            return Ok(_milService.UpdateMilestone(milRequest, milestoneId));
        }

        [HttpDelete("{milestoneId:Guid}")]
        public IActionResult DeleteMilestone(Guid milestoneId)
        {
            _milService.DeleteMilestone(milestoneId);

            return Ok();
        }
    }
}
