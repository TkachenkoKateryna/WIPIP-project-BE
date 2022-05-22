using API.Controllers.Base;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FilesController : BaseApiController
    {

        private readonly IFileStorageService _azureStorageService;

        public FilesController(IFileStorageService azureStorageService)
        {
            _azureStorageService = azureStorageService;
        }

        [HttpPost("imageUpload")]
        public IActionResult UpdateEmployeeImage(IFormFile file)
        {
            try
            {
                return Ok(_azureStorageService.UploadImage(file));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
