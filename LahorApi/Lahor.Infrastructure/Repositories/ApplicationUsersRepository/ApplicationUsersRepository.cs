using AutoMapper;
using Lahor.Core.Dto;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.ApplicationUsersRepository
{
    public class ApplicationUsersRepository : BaseRepository<ApplicationUser, int>, IApplicationUsersRepository
    {
        public ApplicationUsersRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<ApplicationUserDto> FindByUserNameAsync(string UserName)
        {
            return await ProjectToFirstOrDefaultAsync<ApplicationUserDto>(DatabaseContext.Users.Where(c => c.UserName == UserName));
        }
    }
}
