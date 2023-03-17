using Lahor.Core.Entities.Base;
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
        public bool IsAdministrator { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsClient { get; set; }
        public bool IsCompanyOwner { get; set; }
        public ICollection<ApplicationUserRoleDto> UserRoles { get; set; }
    }
}
