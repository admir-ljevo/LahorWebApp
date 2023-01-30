using Lahor.Core.Dto.ApplicationRole;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.ApplicationRolesRepository
{
    public interface IApplicationRolesRepository : IBaseRepository<ApplicationRole, int>
    {
        Task<ApplicationRoleDto> GetByRoleLevelOrName(int roleLevelId, string roleName);
    }
}
