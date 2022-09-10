
using Lahor.Core.Entities.Identity;

namespace Lahor.Core.Dto
{
    public class ApplicationUserRoleDto:BaseDto
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
