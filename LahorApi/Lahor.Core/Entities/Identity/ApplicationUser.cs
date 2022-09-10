using Lahor.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Lahor.Core.Entities.Identity
{
    public class ApplicationUser:IdentityUser<int>,IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool Active { get; set; }
        public Person Person { get; set; }
        public string CompanyName { get; set; }
        public string IdentificationNumberCompany { get; set; }
        public ICollection<ApplicationUserRole> Roles { get; set; }
    }
}
