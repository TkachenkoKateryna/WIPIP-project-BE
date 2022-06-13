using System.Security.Claims;
using API.Controllers.Base;
using Domain.Models.Constants;
using Domain.Models.Dtos.Project;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities.Identity;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.Filters;

namespace API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        readonly IProjectService _projService;
        readonly IPDFService _pdfService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public ProjectController(IProjectService projService, IPDFService pdfService, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _projService = projService;
            _pdfService = pdfService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectsResponse>>> GetProjectsByUser([FromQuery] ProjectFilteringParams param)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            var role = await _roleManager.FindByIdAsync(user.RoleId);

            return Ok(_projService.GetProjects(user.Id, role.Name, param));
        }

        [HttpGet("{projectId}")]
        public ActionResult<ProjectResponse> GetProjectById(string projectId)
        {
            return Ok(_projService.GetProjectById(projectId));
        }

        [HttpPost]
        public ActionResult<ProjectResponse> AddProject(ProjectRequest projectRequest)
        {
            return Ok(_projService.AddProject(projectRequest));
        }

        [HttpPut("{projectId}")]
        public ActionResult<ProjectResponse> UpdateProject(ProjectRequest projectRequest, string projectId)
        {
            return Ok(_projService.UpdateProject(projectRequest, projectId));
        }

        [HttpDelete("{projectId}")]
        public ActionResult<ProjectResponse> DeleteProject(string projectId)
        {
            _projService.DeleteProject(projectId);
            return Ok();
        }

        [HttpGet("{projectId}/file")]
        public FileResult GenerateProjectCharter(string projectId)
        {
            var project = _projService.GetProjectById(projectId);
            var fileStream = _pdfService.GenerateProjectCharter(project);

            string contentType = "application/pdf";
            string fileName = "Output.pdf";

            return File(fileStream, contentType, fileName);
        }

        [HttpGet("{projectId}/budget")]
        public ActionResult<ProjectResponse> CalculateProjectBudget(string projectId)
        {
            return Ok(_projService.CalculateProjectBudget(projectId));
        }

        [HttpPut("{projectId}/status")]
        public IActionResult SetProjectStatus(string projectId, [FromQuery] ProjectStatus status)
        {
            _projService.SetProjectStatus(projectId, status);
            return Ok();
        }
    }
}
