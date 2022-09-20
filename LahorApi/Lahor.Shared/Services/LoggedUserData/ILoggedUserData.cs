using Lahor.Shared.Models;
using System.Security.Claims;

namespace Lahor.Shared.LoggedUserData
{
    public interface ILoggedUserData
    {
        UserDataModel GetUserData(ClaimsPrincipal claimsPrincipal);
    }
}
