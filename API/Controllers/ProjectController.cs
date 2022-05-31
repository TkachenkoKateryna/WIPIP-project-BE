using System.Security.Claims;
using API.Controllers.Base;
using Domain.Models.Constants;
using Domain.Models.Dtos.Project;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities.Identity;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProjectController : BaseApiController
    {
        readonly IProjectService _projService;
        readonly IPDFService _pdfService;
        private readonly UserManager<User> _userManager;

        public ProjectController(
            IProjectService projService,
            IPDFService pdfService,
            UserManager<User> userManager)
        {
            _projService = projService;
            _pdfService = pdfService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet("projects")]
        public async Task<ActionResult<IEnumerable<ProjectsResponse>>> GetProjectsByUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            var roles = await _userManager.GetRolesAsync(user);

            return Ok(_projService.GetProjects(user.Id, roles));
        }

        [AllowAnonymous]
        [HttpGet("projects/{projId}")]
        public ActionResult<ProjectResponse> GetProjectById(string projId)
        {
            return Ok(_projService.GetProjectById(projId));
        }

        [AllowAnonymous]
        [HttpPost("projects")]
        public ActionResult<ProjectResponse> AddProject(ProjectRequest projectRequest)
        {
            return Ok(_projService.AddProject(projectRequest));
        }

        [AllowAnonymous]
        [HttpPut("projects/{projectId}")]
        public ActionResult<ProjectResponse> UpdateProject(ProjectRequest projectRequest, string projectId)
        {
            return Ok(_projService.UpdateProject(projectRequest, projectId));
        }

        [AllowAnonymous]
        [HttpDelete("projects/{projectId}")]
        public ActionResult<ProjectResponse> DeleteProject(string projectId)
        {
            _projService.DeleteProject(projectId);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("projectCharter/{projId}")]
        public FileResult GenerateProjectCharter(string projId)
        {
            var project = _projService.GetProjectById(projId);
            var fileStream = _pdfService.GenerateProjectCharter(project);

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";
            //Define the file name.
            string fileName = "Output.pdf";

            return File(fileStream, contentType, fileName);
        }

        [AllowAnonymous]
        [HttpGet("calculateBudget/{projId}")]
        public ActionResult<ProjectResponse> CalculateProjectBudget(string projId)
        {
            return Ok(_projService.CalculateProjectBudget(projId));
        }

        [AllowAnonymous]
        [HttpPut("changeStatus/{projId}")]
        public IActionResult SetProjectStatus(string projId, [FromQuery] ProjectStatus status)
        {
            _projService.SetProjectStatus(projId, status);
            return Ok();
        }
    }
}
