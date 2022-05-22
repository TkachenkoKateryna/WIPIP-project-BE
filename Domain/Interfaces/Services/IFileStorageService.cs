using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces.Services
{
    public interface IFileStorageService
    {
        string EditFile(byte[] content, string extension, string containerName, string fileRoute, string contentType);
        void DelteFile(string fileRoute, string containerName);
        string UploadImage(IFormFile image);
    }
}
