using Microsoft.AspNetCore.Http;

namespace Lahor.Core.Dto.New
{
    public class NewUpdateDto:BaseDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string? Image { get; set; }
        public string Text { get; set; }
        public bool Public { get; set; }
        public IFormFile? File { get; set; }
    }
}
