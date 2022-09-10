using Lahor.Core.Enumerations;
using Lahor.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace Lahor.API.Services.UserManager
{
    public interface IUserManager
    {
        UserDataModel GetUserModel();
        Task<LoginInformation> SignInAsync(string email, string password, bool rememberMe);
        Task SignOut();
        bool IsSignedIn();
        bool IsInRoles(params Role[] roles);
        bool IsPasswordActive();
        Task<IdentityResult> ValidatePassword(string password, string currentPassword);
        Task<IdentityResult> ChangePassword(string currentPassword, string newPassword);
        Task ResetPassword(string email);
        Task ResetClaims();
    }
}
