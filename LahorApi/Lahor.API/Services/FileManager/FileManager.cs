using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Net.Http.Headers;

namespace Lahor.API.Services.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileManager(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var filePath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return filePath;
            }
            return null;
        }

        public async Task<string> UploadThumbnailPhoto(IFormFile file)
        {
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var filePath = Path.Combine(folderName, fileName);
                using var image = await Image.LoadAsync(file.OpenReadStream());
                image.Mutate(x => x.Resize(100, 100));
                await image.SaveAsync(filePath);

                return filePath;
            }
            return null;

        }


        private string NormalizePath(string path)
        {
            return "/" + path.Replace(Path.DirectorySeparatorChar, '/');
        }
    }
}
