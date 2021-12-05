using LahorWebApp.Models;
using LahorWebApp.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LahorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController:ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<Korisnik> _userManager;
        private readonly SignInManager<Korisnik> _signInManager;
        private readonly JWTConfig _jwtConfig; 

         public UserController(ILogger<UserController> logger,
             UserManager<Korisnik> userManager,
             SignInManager<Korisnik> signInManager,
             IOptions<JWTConfig> jwtConfig)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig.Value;
        }

        [HttpPost]
        public async Task<Object> RegisterUser([FromBody] AccountModel model)
        {
            try
            {
                var user = new Korisnik()
                {
                    UserName = model.Username,
                    EmailAdresa = model.Email
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    return await Task.FromResult("Korisnik uspješno registrovan");
                }
                return await Task.FromResult(string.Join(",", result.Errors.Select(
                    x => x.Description).ToArray()));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(ex.Message);
            }
            
        }

        [HttpGet]

        public async Task<object> GetAllUser()
        {
            try
            {
                var korisnici = _userManager.Users.Select(x => new UserVM(
                      x.UserName, x.Email));
                return await Task.FromResult(korisnici);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(ex.Message);
            }
        }

        [HttpPost]
        
        public async Task<object> Login([FromBody] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Username,
                        model.Password, false, false);
                    if (result.Succeeded)
                    {
                        var appUser = await _userManager.FindByNameAsync(model.Username);
                        var user = new UserVM(appUser.UserName, appUser.Email);
                        user.Token = GenerateToken(appUser);
                        return await Task.FromResult(user);
                    }
                }
                return await Task.FromResult("Username ili password nisu validni");
            }
            catch (Exception ex)
            {

                return await Task.FromResult(ex.Message);
            }
        }
        private string GenerateToken(Korisnik user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId,user.Id),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email,user.Email),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature),
                Audience=_jwtConfig.Audience,
                Issuer=_jwtConfig.Issuer
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
