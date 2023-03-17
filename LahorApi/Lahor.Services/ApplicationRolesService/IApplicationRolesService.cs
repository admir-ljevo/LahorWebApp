using Lahor.Core.Dto.ApplicationRole;
using Lahor.Services.BaseService;

namespace Lahor.Services.ApplicationRolesService
{
    public interface IApplicationRolesService: IBaseService<ApplicationRoleDto>
    {
        Task<ApplicationRoleDto> GetByRoleLevelIdOrName(int roleLeveleId, string roleName);
    }
}
