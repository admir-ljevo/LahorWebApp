using Lahor.Core.Dto;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.ApplicationUserRolesRepository
{
    public interface IApplicationUserRolesRepository : IBaseRepository<ApplicationUserRole, int>
    {
        Task<IEnumerable<ApplicationUserRoleDto>> GetByUserId(int pUserId);
    }
}
