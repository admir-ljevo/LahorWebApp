using Lahor.Core.Entities;
using Lahor.Core.Entities.Base;
using Lahor.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Lahor.Core.Dto
{
    public class ApplicationUserDto : IdentityUser<int>, IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool Active { get; set; }
        public int PersonId { get; set; }
        public PersonDto Person { get; set; }
        public string CompanyName { get; set; }
        public string IdentificationNumberCompany { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
