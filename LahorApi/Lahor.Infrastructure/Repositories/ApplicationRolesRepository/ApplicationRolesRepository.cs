using AutoMapper;
using Lahor.Core.Dto.ApplicationRole;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.ApplicationRolesRepository
{
    public class ApplicationRolesRepository : BaseRepository<ApplicationRole, int>, IApplicationRolesRepository
    {
        public ApplicationRolesRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {

        }
        public async Task<ApplicationRoleDto> GetByRoleLevelOrName(int roleLevelId, string roleName)
        {
            var role = DatabaseContext.Roles.FirstOrDefault(c => c.RoleLevel == roleLevelId || c.Name==roleName);
            return Mapper.Map<ApplicationRoleDto>(role);
        }

    }
}
