using Application.Interfaces;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StakeholdersController : BaseApiController
    {
        readonly IStakeholdersService _stakeholderService;

        public StakeholdersController(IStakeholdersService stakeholderService)
        {
            _stakeholderService = stakeholderService;
        }

        [HttpGet("stakeholdersByProject/{projId}")]
        public ActionResult<IEnumerable<StakeholderResponse>> GetAllStakeholdersByProject(string projId)
        {
            return Ok(_stakeholderService.GetAllStakeholdersByProject(projId));
        }

        [HttpGet("stakeholders")]
        public ActionResult<IEnumerable<StakeholderResponse>> GetAllStakeholders(string projId)
        {
            return Ok(_stakeholderService.GetAllStakeholders());
        }

        [HttpPut("stakeholders/add")]
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

        [HttpPut("stakeholders/update/{stId}")]
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

        [HttpDelete("stakeholders/delete")]
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
