
using Lahor.Core.Dto;
using Lahor.Services.BaseService;

namespace Lahor.Services.ApplicationUserRolesService
{
    public interface IApplicationUserRolesService: IBaseService<ApplicationUserRoleDto>
    {
        Task<IEnumerable<ApplicationUserRoleDto>> GetByUserId(int pUserId);
    }
}
