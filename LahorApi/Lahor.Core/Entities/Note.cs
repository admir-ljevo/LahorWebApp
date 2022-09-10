using Lahor.Core.Entities.Base;
using Lahor.Core.Entities.Identity;

namespace Lahor.Core.Entities
{
    public class Note:BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public bool Public { get; set; }
    }
}
