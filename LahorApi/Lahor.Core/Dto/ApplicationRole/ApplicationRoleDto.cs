using Lahor.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Lahor.Core.Dto.ApplicationRole
{
    public class ApplicationRoleDto : IdentityRole<int>, IBaseEntity
    {
        public int? RoleLevel { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ApplicationUserRoleDto> UserRoles { get; set; }

    }
}
