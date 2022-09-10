using Lahor.Core.Dto;
using Lahor.Services.BaseService;

namespace Lahor.Services.ApplicationUsersService
{
    public interface IApplicationUsersService : IBaseService<ApplicationUserDto>
    {
        Task<ApplicationUserDto> FindByUserNameAsync(string pUserName);
    }
}
