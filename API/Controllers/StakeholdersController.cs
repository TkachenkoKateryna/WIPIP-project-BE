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
    [ApiController]
    [Route("api/stakeholders")]
    public class StakeholdersController : ControllerBase
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

        [HttpGet]
        public ActionResult<IEnumerable<StakeholderResponse>> GetStakeholders()
        {
            _logger.LogInfo("Fetching stakeholders");

            var stakeholders = _stakeholderService.GetStakeholders();

            _logger.LogInfo($"Returning {stakeholders.Count()} stakeholders.");

            return Ok(stakeholders);
        }

        [HttpPost]
        public ActionResult<StakeholderResponse> AddStakeholder(StakeholderRequest stRequest)
        {
            var stResp = _stakeholderService.AddStakeholder(stRequest);

            return Ok(stResp);
        }

        [HttpPut("{stakeholderId}")]
        public ActionResult<StakeholderResponse> UpdateStakeholder(StakeholderRequest stRequest, string stakeholderId)
        {
            var stResp = _stakeholderService.UpdateStakeholder(stRequest, stakeholderId);

            return Ok(stResp);
        }

        [HttpDelete("{stakeholderId}")]
        public IActionResult DeleteStakeholder(string stakeholderId)
        {
            _stakeholderService.DeleteStakeholder(stakeholderId);

            return Ok();
        }

        [HttpDelete("{stakeholderId}/projects/{projectId}")]
        public ActionResult<StakeholderResponse> RemoveStakeholderFromProject(string projectId, string stakeholderId)
        {
            _stakeholderService.RemoveStakeholderFromProject(projectId, stakeholderId);

            return Ok();
        }

        [HttpPut("{stakeholderId}/projects/{projectId}")]
        public ActionResult<StakeholderResponse> AddStakeholderToProject(string projectId, string stakeholderId)
        {
            var stResp = _stakeholderService.AddStakeholderToProject(projectId, stakeholderId);

            return Ok(stResp);
        }

        [HttpGet("file")]
        public FileResult GetFile([FromQuery] string projectId, [FromQuery] string projectTitle)
        {
            return File(
                _excelService.GenerateStakeholderRegisterXml(projectId, projectTitle),
                "application/xml",
                "stakeholders.xlsx");
        }
    }
}
