using API.Controllers.Base;
using Application.Interfaces;
using Application.Interfaces.Util;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StakeholdersController : BaseApiController
    {
        readonly IStakeholdersService _stakeholderService;

        public StakeholdersController(
            IStakeholdersService stakeholderService)
        {
            _stakeholderService = stakeholderService;
        }

        [HttpGet("stakeholders")]
        public ActionResult<IEnumerable<StakeholderResponse>> GetAllStakeholders(string projId)
        {
            return Ok(_stakeholderService.GetAllStakeholders());
        }

        [HttpPost("stakeholders")]
        public ActionResult<StakeholderResponse> AddStakeholder(StakeholderRequest stRequest)
        {
            try
            {
                var stResp = _stakeholderService.AddStakeholder(stRequest);
                return Ok(stResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("stakeholders/{stId}")]
        public ActionResult<StakeholderResponse> UpdateStakeholder(StakeholderRequest stRequest, string stId)
        {
            try
            {
                var stResp = _stakeholderService.UpdateStakeholder(stRequest, stId);
                return Ok(stResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("stakeholders")]
        public IActionResult DeleteStakeholder(StakeholderDeleteRequest stRequest)
        {
            try
            {
                _stakeholderService.DeleteStakeholder(stRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
