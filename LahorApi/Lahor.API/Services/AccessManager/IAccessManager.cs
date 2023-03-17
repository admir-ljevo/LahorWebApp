using Lahor.Core.Enumerations;
using Lahor.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace Lahor.API.Services.AccessManager
{
    public interface IAccessManager
    {
        Task<LoginInformation> SignInAsync(string email, string password, bool rememberMe);
        Task<IdentityResult> ChangePassword(string currentPassword, string newPassword);
        Task ResetPassword(string email);
    }
}
