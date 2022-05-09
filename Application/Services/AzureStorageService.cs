using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Application.Services
{
    public class AzureStorageService : IFileStorageService
    {
        private readonly string connectionString;
        public AzureStorageService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorageConnection");
        }
        public void DelteFile(string fileRoute, string containerName)
        {
            if (fileRoute != null)
            {
                var account = CloudStorageAccount.Parse(connectionString);
                var client = account.CreateCloudBlobClient();
                var container = client.GetContainerReference(containerName);

                var blobName = Path.GetFileName(fileRoute);
                var blob = container.GetBlobReference(blobName);
                blob.DeleteIfExistsAsync();
            }
        }

        public string EditFile(byte[] content, string extension, string containerName, string fileRoute, string contentType)
        {
            DelteFile(fileRoute, containerName);
            return SaveFile(content, extension, containerName, contentType);
        }

        public string SaveFile(byte[] content, string extension, string containerName, string contentType)
        {
            var account = CloudStorageAccount.Parse(connectionString);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);
            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            var fileName = $"{Guid.NewGuid()}{extension}";
            var blob = container.GetBlockBlobReference(fileName);
            blob.UploadFromByteArrayAsync(content, 0, content.Length);
            return blob.Uri.ToString();
        }

    }
}
