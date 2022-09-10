using Lahor.Core.Dto;
using Lahor.Core.Entities.Identity;
using Lahor.Core.Enumerations;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Services.ApplicationUserRolesService;
using Lahor.Services.ApplicationUsersService;
using Lahor.Shared.Constants;
using Lahor.Shared.Extensions;
using Lahor.Shared.LoggedUserData;
using Lahor.Shared.Models;
using Lahor.Shared.Services.Crypto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lahor.API.Services.UserManager
{
    public class UserManager : IUserManager
    {
        private const string SessionKey = "user";

        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ICrypto _crypto;
        private readonly ISession _session;
        private readonly ILoggedUserData _loggedUserData;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplicationUsersService _applicationUsersService;
        private readonly IApplicationUserRolesService _applicationUserRolesService;
        private readonly JWTConfig _jwtConfig;
        private HttpContext HttpContext => _httpContextAccessor.HttpContext;

        public UserManager(ICrypto crypto, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
                           IApplicationUsersService applicationUsersService, SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager, ILoggedUserData loggedUserData, IApplicationUsersService applicationUser,IApplicationUserRolesService applicationUserRolesService, IOptions<JWTConfig> jwtConfig)
        {
            _crypto = crypto;
            _httpContextAccessor = httpContextAccessor;
            _applicationUsersService = applicationUsersService;
            _unitOfWork = (UnitOfWork)unitOfWork;
            _session = httpContextAccessor.HttpContext?.Session;
            _signInManager = signInManager;
            _userManager = userManager;
            _loggedUserData = loggedUserData;
            _applicationUserRolesService = applicationUserRolesService;
            _jwtConfig = jwtConfig.Value;

        }

        public UserDataModel GetUserModel()
        {
            return _loggedUserData.GetUserData(HttpContext.User);
        }

        public async Task<LoginInformation> SignInAsync(string username, string password, bool rememberMe = false)
        {
            LoginInformation loginInformation = new LoginInformation();
            try
            {
                var resultSignIn = await _signInManager.PasswordSignInAsync(username, password,false,false);
                if(resultSignIn.Succeeded)
                {
                    var user = await _applicationUsersService.FindByUserNameAsync(username);
                    if (user == null)
                        throw new UserNotFoundException();
                    await ResetClaims(user, rememberMe);
                    loginInformation=new LoginInformation
                    {
                        User = user,
                        Token = GenerateToken(user)
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return loginInformation;
        }
        private async Task ResetClaims(ApplicationUserDto user, bool rememberMe = false)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Person.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.Person.LastName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            if (user.Person.ProfilePhotoThumbnail.IsSet())
                identity.AddClaim(new Claim(CustomClaimTypes.ProfilePhoto, user.Person.ProfilePhotoThumbnail));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
            {
                IsPersistent = rememberMe
            });
        }

        public bool IsSignedIn()
        {
            return HttpContext.User?.IsLoggedIn() ?? false;
        }

        public bool IsInRoles(params Role[] roles)
        {
            return HttpContext.User.IsInRoles(roles);
        }
        public async Task ResetClaims()
        {
            await ResetClaims(await _applicationUsersService.FindByUserNameAsync(GetUserModel().Username));
        }
        public bool IsPasswordActive()
        {
            var item = bool.Parse(HttpContext.User?.GetClaimValue(CustomClaimTypes.Active));
            return item;
        }
        public async Task<IdentityResult> ValidatePassword(string currentPassword, string password)
        {
            var validators = _userManager.PasswordValidators;

            var passwordHash = (await _applicationUsersService.FindByUserNameAsync(GetUserModel().Username)).PasswordHash;

            if (!await _userManager.CheckPasswordAsync(new ApplicationUser() { PasswordHash = passwordHash }, currentPassword))
            {
                return IdentityResult.Failed(new IdentityError() { Description="Šifre se ne podudaraju" });
            }

            foreach (var validator in validators)
            {
                var result = await validator.ValidateAsync(_userManager, null, password);
                if (!result.Succeeded)
                    return result;

            }
            return null;
        }

        public async Task<IdentityResult> ChangePassword(string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(await _userManager.FindByIdAsync(GetUserModel().Id.ToString()), currentPassword, newPassword);
        }

        public async Task ResetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var newPassword = _crypto.GeneratePassword();
            await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), newPassword);
           // await _email.Send(EmailMessages.ResetPasswordSubject, EmailMessages.ResetPasswordEmail(newPassword), email);
        }
        public async Task SignOut()
        {
            await HttpContext.SignOutAsync();
        }
        private string GenerateToken(ApplicationUserDto user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email,user.Email),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                //new System.Security.Claims.Claim(ClaimTypes.Role,role),
            }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtConfig.Audience,
                Issuer = _jwtConfig.Issuer
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = null) : base(message) { }
    }

    public class WrongCredentialsException : Exception
    {
        public ApplicationUserDto User { get; set; }

        public WrongCredentialsException(ApplicationUserDto user, string message = null) : base(message)
        {
            User = user;
        }
    }
}
