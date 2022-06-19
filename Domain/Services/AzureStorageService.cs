using Domain.Interfaces.Services.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;

namespace Domain.Services
{
    public class AzureStorageService : IFileStorageService
    {
        private readonly string connectionString;

        private readonly string containerName = "wipipresources";

        public AzureStorageService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorageConnection");
        }

        public string UploadImage(IFormFile image)
        {
            var result = "";

            if (image != null)
            {
                using var memoryStream = new MemoryStream();
                image.CopyTo(memoryStream);
                var content = memoryStream.ToArray();
                var extension = Path.GetExtension(image.FileName);
                result = SaveFile(content, extension, containerName, image.ContentType);
            }
            else
            {
                throw new ArgumentNullException("Image doesn't exist");
            }

            return result;
        }

        private string SaveFile(byte[] content, string extension, string containerName, string contentType)
        {
            var account = CloudStorageAccount.Parse(connectionString);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);
            container.CreateIfNotExists();
            container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            var fileName = $"{Guid.NewGuid()}{extension}";
            var blob = container.GetBlockBlobReference(fileName);
            blob.UploadFromByteArray(content, 0, content.Length);

            return blob.Uri.ToString();
        }
    }
}
