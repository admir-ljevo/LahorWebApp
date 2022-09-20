using Lahor.Core.Entities.Identity;
using Microsoft.AspNetCore.Http;

namespace Lahor.Core.Dto.New
{
    public class NewDto:BaseDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public ApplicationUserDto User { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public bool Public { get; set; }
    }
}
