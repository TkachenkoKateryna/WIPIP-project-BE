using Application.Interfaces;
using Application.Interfaces.Util;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProjectController : BaseApiController
    {
        readonly IProjectService _projService;
        readonly IPDFService _pdfService;

        public ProjectController(IProjectService projService, IPDFService pdfService)
        {
            _projService = projService;
            _pdfService = pdfService;
        }

        [HttpGet("project/{projId}")]
        public ActionResult<IEnumerable<ProjectResponse>> GetAllProjectById(string projId)
        {
            return Ok(_projService.GetProjectById(projId));
        }

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
    }
}
