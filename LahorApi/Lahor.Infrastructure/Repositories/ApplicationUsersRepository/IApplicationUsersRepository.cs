
using Lahor.Core.Dto;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.ApplicationUsersRepository
{
    public interface IApplicationUsersRepository : IBaseRepository<ApplicationUser, int>
    {
        Task<ApplicationUserDto> FindByUserNameAsync(string UserName);
    }
}
