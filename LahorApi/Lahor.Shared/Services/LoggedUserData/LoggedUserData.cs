using Lahor.Shared.Constants;
using Lahor.Shared.Extensions;
using Lahor.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Lahor.Shared.LoggedUserData
{
    public class LoggedUserData : ILoggedUserData
    {
        public UserDataModel GetUserData(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null || claimsPrincipal.Claims.IsEmpty())
                return null;

            var id = int.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.Sid));
            var username = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var firstName = claimsPrincipal.FindFirstValue(ClaimTypes.Name);
            var lastName = claimsPrincipal.FindFirstValue(ClaimTypes.Surname);
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

            var phoneNumber = string.Empty;
            string profilePhoto = null;
            string currentCompanyCurrencySign = null;


            if (claimsPrincipal.HasClaim(c => c.Type == ClaimTypes.MobilePhone))
                phoneNumber = claimsPrincipal.FindFirstValue(ClaimTypes.MobilePhone);

            if (claimsPrincipal.HasClaim(c => c.Type == CustomClaimTypes.ProfilePhoto))
                profilePhoto = claimsPrincipal.FindFirstValue(CustomClaimTypes.ProfilePhoto);

            return new UserDataModel
            {
                Id = id,
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                ProfilePhoto = profilePhoto,
            };
        }


    }
}
