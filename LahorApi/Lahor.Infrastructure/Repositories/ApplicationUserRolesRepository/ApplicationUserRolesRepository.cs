using AutoMapper;
using Lahor.Core.Dto;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.ApplicationUserRolesRepository
{
    public class ApplicationUserRolesRepository : BaseRepository<ApplicationUserRole, int>, IApplicationUserRolesRepository
    {
        public ApplicationUserRolesRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {

        }
        public async Task<IEnumerable<ApplicationUserRoleDto>> GetByUserId(int pUserId)
        {
            //return DbConnection.QueryFunctionAsync<ApplicationUserRoleDto>("fn_userroles_getbyuserid", new { pUserId });
            return await ProjectToListAsync<ApplicationUserRoleDto>(DatabaseContext.UserRoles.Where(c => c.UserId == pUserId));
        }

    }
}
