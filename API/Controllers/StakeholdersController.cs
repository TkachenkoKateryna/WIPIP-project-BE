using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Domain.Models.Dtos.Responses;
using Domain.Models.Dtos.Stakeholder;
using Domain.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/stakeholders")]
    public class StakeholdersController : ControllerBase
    {
        private readonly IStakeholdersService _stakeholderService;
        private readonly IExcelService _excelService;

        public StakeholdersController(IStakeholdersService stakeholderService, IExcelService excelService)
        {
            _stakeholderService = stakeholderService;
            _excelService = excelService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StakeholderResponse>> GetStakeholders([FromQuery] StakeholderFiteringParam param = null)
        {
            return Ok(_stakeholderService.GetStakeholders(param));
        }

        [HttpGet("file")]
        public FileResult GetFile([FromQuery] Guid projectId, [FromQuery] string projectTitle)
        {
            return File(_excelService.GenerateStakeholderRegisterXml(projectId, projectTitle),
                "application/xml",
                "stakeholders.xlsx");
        }

        [HttpPost]
        public ActionResult<StakeholderResponse> AddStakeholder(StakeholderRequest stRequest)
        {
            return Ok(_stakeholderService.AddStakeholder(stRequest));
        }

        [HttpPut("{stakeholderId:Guid}")]
        public ActionResult<StakeholderResponse> UpdateStakeholder(StakeholderRequest stRequest, Guid stakeholderId)
        {
            return Ok(_stakeholderService.UpdateStakeholder(stRequest, stakeholderId));
        }

        [HttpPut("{stakeholderId:Guid}/projects/{projectId}")]
        public ActionResult<StakeholderResponse> AddStakeholderToProject(Guid projectId, Guid stakeholderId)
        {
            return Ok(_stakeholderService.AddStakeholderToProject(projectId, stakeholderId));
        }

        [HttpDelete("{stakeholderId:Guid}")]
        public IActionResult DeleteStakeholder(Guid stakeholderId)
        {
            _stakeholderService.DeleteStakeholder(stakeholderId);

            return Ok();
        }

        [HttpDelete("{stakeholderId:Guid}/projects/{projectId:Guid}")]
        public ActionResult<StakeholderResponse> RemoveStakeholderFromProject(Guid projectId, Guid stakeholderId)
        {
            return Ok(_stakeholderService.RemoveStakeholderFromProject(projectId, stakeholderId));
        }
    }
}
