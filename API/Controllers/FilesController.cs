using Domain.Interfaces.Services.Util;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class FilesController : ControllerBase
    {
        private readonly IFileStorageService _azureStorageService;

        public FilesController(IFileStorageService azureStorageService)
        {
            _azureStorageService = azureStorageService;
        }

        [HttpPost("images/upload")]
        public IActionResult UploadImage(IFormFile file)
        {
            return Ok(_azureStorageService.UploadImage(file));
        }
    }
}
