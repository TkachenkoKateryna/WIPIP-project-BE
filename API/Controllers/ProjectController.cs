using System.Security.Claims;
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
        public ProjectController(
            IProjectService projService,
            IPDFService pdfService,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _projService = projService;
            _pdfService = pdfService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectsResponse>>> GetProjectsByUser([FromQuery] ProjectFilteringParams param)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = await _roleManager.FindByIdAsync(user.RoleId);

            return Ok(_projService.GetProjects(user.Id, role.Name, param));
        }

        [HttpGet("{projectId:Guid}")]
        public ActionResult<ProjectResponse> GetProjectById(Guid projectId)
        {
            return Ok(_projService.GetProjectById(projectId));
        }

        [HttpGet("{projectId:Guid}/budget")]
        public ActionResult<ProjectResponse> CalculateProjectBudget(Guid projectId)
        {
            return Ok(_projService.CalculateProjectBudget(projectId));
        }

        [HttpGet("{projectId:Guid}/file")]
        public FileResult GenerateProjectCharter(Guid projectId)
        {
            var project = _projService.GetProjectById(projectId);
            var fileStream = _pdfService.GenerateProjectCharter(project);

            string contentType = "application/pdf";
            string fileName = "Output.pdf";

            return File(fileStream, contentType, fileName);
        }

        [HttpPost]
        public ActionResult<ProjectResponse> AddProject(ProjectRequest projectRequest)
        {
            return Ok(_projService.AddProject(projectRequest));
        }

        [HttpPut("{projectId:Guid}")]
        public ActionResult<ProjectResponse> UpdateProject(ProjectRequest projectRequest, Guid projectId)
        {
            return Ok(_projService.UpdateProject(projectRequest, projectId));
        }

        [HttpPut("{projectId:Guid}/status")]
        public IActionResult SetProjectStatus(Guid projectId, [FromQuery] ProjectStatus status)
        {
            _projService.SetProjectStatus(projectId, status);
            return Ok();
        }

        [HttpDelete("{projectId:Guid}")]
        public ActionResult<ProjectResponse> DeleteProject(Guid projectId)
        {
            _projService.DeleteProject(projectId);

            return Ok();
        }

    }
}
