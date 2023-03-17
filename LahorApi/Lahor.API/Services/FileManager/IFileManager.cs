namespace Lahor.API.Services.FileManager
{
    public interface IFileManager
    {
        Task<string> UploadFile(IFormFile file);
        Task<string> UploadThumbnailPhoto(IFormFile file);
        string GeneratePathForReport(string path);
    }
}