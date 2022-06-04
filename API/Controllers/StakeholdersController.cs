using API.Controllers.Base;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Domain.Interfaces.Util;
using Domain.Models.Constants;
using Domain.Models.Dtos.Responses;
using Domain.Models.Dtos.Stakeholder;
using Domain.Models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{

    public class StakeholdersController : BaseApiController
    {
        private readonly IStakeholdersService _stakeholderService;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly IExcelService _excelService;


        public StakeholdersController(
            IStakeholdersService stakeholderService,
            UserManager<User> userManager,
            ILoggerManager logger,
            IExcelService excelService)
        {
            _stakeholderService = stakeholderService;
            _userManager = userManager;
            _logger = logger;
            _excelService = excelService;
        }

        [HttpGet(Strings.StakeholderRoute)]
        public async Task<ActionResult<IEnumerable<StakeholderResponse>>> GetStakeholders()
        {
            _logger.LogInfo("Fetching stakeholders");

            var stakeholders = _stakeholderService.GetStakeholders();

            _logger.LogInfo($"Returning {stakeholders.Count()} stakeholders.");

            return Ok(stakeholders);
        }

        [HttpGet(Strings.ProjectStakeholderRoute)]
        public ActionResult<IEnumerable<StakeholderResponse>> GetStakeholders([FromQuery] string projectId)
        {
            _logger.LogInfo($"Fetching stakeholders that are not assigned to project with id {projectId}");

            var stakeholders = _stakeholderService.GetStakeholders(projectId);

            _logger.LogInfo($"Returning {stakeholders.Count()} stakeholders.");

            return Ok(stakeholders);
        }

        [HttpPost(Strings.StakeholderRoute)]
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

        [HttpDelete(Strings.ProjectStakeholderRoute)]
        public ActionResult<StakeholderResponse> RemoveStakeholderFromProject(StakeholderProjectRequest stRequest)
        {
            try
            {
                _stakeholderService.RemoveStakeholderFromProject(stRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Strings.ProjectStakeholderRoute)]
        public ActionResult<StakeholderResponse> AddStakeholderToProject(StakeholderProjectRequest stRequest)
        {
            try
            {
                var stResp = _stakeholderService.AddStakeholderToProject(stRequest);
                return Ok(stResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut(Strings.StakeholderRoute + "{stId}")]
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

        [HttpDelete(Strings.StakeholderRoute)]
        public IActionResult DeleteStakeholder(StakeholderProjectRequest stRequest)
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

        [HttpGet(Strings.StakeholderRoute + "dowbloadExcel")]
        public FileResult Excel([FromQuery] string projectId, [FromQuery] string projectTitle)
        {
            return File(
                _excelService.GenerateStakeholderRegisterXml(projectId, projectTitle),
                "application/xml",
                "stakeholders.xlsx");
        }
    }
}
