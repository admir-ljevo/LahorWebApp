using Lahor.Core.Dto.ApplicationRole;

namespace Lahor.Core.Dto
{
    public class ApplicationUserRoleDto:BaseDto
    {
        public ApplicationUserDto User { get; set; }
        public ApplicationRoleDto Role { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
