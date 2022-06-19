using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces.Services.Util
{
    public interface IFileStorageService
    {
        string UploadImage(IFormFile image);
    }
}
