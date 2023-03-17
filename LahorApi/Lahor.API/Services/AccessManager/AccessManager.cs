using Lahor.Core.Dto;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Services.ApplicationUsersService;
using Lahor.Shared.Constants;
using Lahor.Shared.Extensions;
using Lahor.Shared.Models;
using Lahor.Shared.Services.Crypto;
using Lahor.Shared.Services.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lahor.API.Services.AccessManager
{
    public class AccessManager : IAccessManager
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICrypto _cryptoService;
        private readonly IApplicationUsersService _applicationUsersService;
        private readonly IConfiguration _configuration;
        private readonly IEmail _email;
        private readonly JWTConfig _jwtConfig;

        public AccessManager(ICrypto cryptoService, IUnitOfWork unitOfWork,
                            IApplicationUsersService applicationUsersService, UserManager<ApplicationUser> userManager, IOptions<JWTConfig> jwtConfig, IConfiguration configuration, IEmail email)
        {
            _cryptoService = cryptoService;
            _applicationUsersService = applicationUsersService;
            _unitOfWork = (UnitOfWork)unitOfWork;
            _userManager = userManager;
            _jwtConfig = jwtConfig.Value;
            _configuration = configuration;
            _email = email;

        }

        public async Task<LoginInformation> SignInAsync(string username, string password, bool rememberMe = false)
        {
                var user = await _applicationUsersService.FindByUserNameOrEmailAsync(username);
                if (user == null)
                {
                    throw new UserNotFoundException();
                }

                if (!await _userManager.CheckPasswordAsync(new ApplicationUser() { PasswordHash = user.PasswordHash }, password))
                {
                    throw new WrongCredentialsException(user);
                }

                var loginInformation = new LoginInformation
                {
                    User = user,
                    Token = GenerateToken(user)
                };
                return loginInformation;

        }

        public async Task<IdentityResult> ChangePassword(string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(await _userManager.FindByIdAsync("testId"), currentPassword, newPassword);
        }

        public async Task ResetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var newPassword = _cryptoService.GeneratePassword();
            await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), newPassword);
            await _email.Send(EmailMessages.ResetPasswordSubject, EmailMessages.ResetPasswordEmail(newPassword), email);
        }
        private string GenerateToken(ApplicationUserDto user)
        {

            var claims = CreateClaims(user);

            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection(ConfigurationValues.TokenKey).Value));
            var signInCreds = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(int.Parse(_configuration.GetSection(ConfigurationValues.TokenValidityInMinutes).Value)), signingCredentials: signInCreds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private IEnumerable<Claim> CreateClaims(ApplicationUserDto user)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(nameof(user.Id), user.Id.ToString()));
            identity.AddClaim(new Claim(nameof(user.Email), user.Email));
            identity.AddClaim(new Claim(nameof(user.Person.FirstName), user.Person.FirstName));
            identity.AddClaim(new Claim(nameof(user.Person.LastName), user.Person.LastName));

            if (user.Person.ProfilePhoto.IsSet())
                identity.AddClaim(new Claim(CustomClaimTypes.ProfilePhoto, CustomClaimTypes.ProfilePhoto));

            if (user.Person.ProfilePhotoThumbnail.IsSet())
                identity.AddClaim(new Claim(CustomClaimTypes.ProfilePhoto, user.Person.ProfilePhotoThumbnail));
            foreach (var item in user.UserRoles)
                identity.AddClaim(new Claim(ClaimTypes.Role, item.RoleId.ToString()));

            return identity.Claims;
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

