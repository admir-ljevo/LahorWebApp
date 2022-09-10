using Lahor.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Lahor.Core.Entities.Identity
{
    public class ApplicationRole: IdentityRole<int>,IBaseEntity
    {
        public int? RoleLevel { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ApplicationUserRole> Roles { get; set; }

    }
}
