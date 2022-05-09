namespace Application.Interfaces
{
    public interface IFileStorageService
    {
        string EditFile(byte[] content, string extension, string containerName, string fileRoute, string contentType);
        void DelteFile(string fileRoute, string containerName);
        string SaveFile(byte[] content, string extension, string containerName, string contentType);
    }
}
