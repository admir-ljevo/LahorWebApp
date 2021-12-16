using Data.Enum;
using Data.Models;
using LahorWebApp.ViewModels;
using LahorWebApp.Views;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWTConfig _jwtConfig; 

         public UserController(ILogger<UserController> logger,
             UserManager<Korisnik> userManager,
             SignInManager<Korisnik> signInManager,
             RoleManager<IdentityRole> roleManager,
        IOptions<JWTConfig> jwtConfig)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtConfig = jwtConfig.Value;
        }

        [HttpPost]
        public async Task<Object> RegisterUser([FromBody] AccountModel model)
        {
            try
            {
                if(!await _roleManager.RoleExistsAsync(model.Role))
                {
                    return await Task.FromResult(new ResponseModel(
                        ResponseCode.Error,"Ne postoji rola za korisnika",null));
                }
                var user = new Korisnik()
                {
                    UserName = model.Username,
                    EmailAdresa = model.Email
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    var tempUser = await _userManager.FindByNameAsync(model.Username);
                    await _userManager.AddToRoleAsync(tempUser, model.Role);
                    return await Task.FromResult(new ResponseModel(
                        ResponseCode.OK,"Registracija uspješna",user));
                }
                return await Task.FromResult(string.Join(",", result.Errors.Select(
                    x => x.Description).ToArray()));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error, ex.Message, null));
            }
            
        }

        [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<object> GetAllUser()
        {
            try
            {
                    var korisnici = _userManager.Users.Select(x => new User(
                    x.UserName, x.EmailAdresa, x.Adresa, x.BrojTelefona)).ToList();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK,
                    "Korisnici uspješno preuzeti",korisnici));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error,ex.Message,null));
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
                        var role = (await _userManager.GetRolesAsync(appUser)).FirstOrDefault();
                        var user = new LoginInformation(appUser,role);
                        user.Token = GenerateToken(appUser,role);
                        return await Task.FromResult(new ResponseModel(
                            ResponseCode.OK,"Uspješna prijava",user));
                    }
                }
                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error,"Username ili password nisu ispravni",null));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error,ex.Message,null));
            }
        }
        //[Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<object> AddRole([FromBody] RoleModel model)
        {
            try
            {
                if(model==null || model.Role=="")
                {
                    return await Task.FromResult(new ResponseModel(
                        ResponseCode.Error,"Podaci nisu validni",null));
                }
                if(await _roleManager.RoleExistsAsync(model.Role))
                {
                    return await Task.FromResult(new ResponseModel(
                        ResponseCode.Error,"Rola već postoji",null));
                }
                var role = new IdentityRole();
                role.Name = model.Role;
                var result = await _roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return await Task.FromResult(new ResponseModel(
                        ResponseCode.OK,"Rola uspješno dodana",null));
                }
                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error, "Nemoguće dodati rolu", null));
                
            }
            catch (Exception ex)
            {

                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error,ex.Message,null));
            }
        }
        private string GenerateToken(Korisnik user,string role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId,user.Id),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email,user.EmailAdresa),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new System.Security.Claims.Claim(ClaimTypes.Role,role),
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
