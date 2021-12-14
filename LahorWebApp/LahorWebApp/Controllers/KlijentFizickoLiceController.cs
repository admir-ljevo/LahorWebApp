using Data.Enum;
using Data.Models;
using LahorWebApp.Data;
using LahorWebApp.Models;
using LahorWebApp.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KlijentFizickoLiceController : ControllerBase
    {
        private readonly LahorAppDBContext dBContext;
        private UserManager<Korisnik> _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly SignInManager<Korisnik> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<JWTConfig> _jwtConfig;

        public KlijentFizickoLiceController(
            LahorAppDBContext dBContext,
            UserManager<Korisnik> userManager,
            ILogger<UserController> logger,
            SignInManager<Korisnik> signInManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JWTConfig> jwtConfig)
        {
            this.dBContext = dBContext;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtConfig = jwtConfig;

        }
        [HttpPost]
        public async Task<object> Add(KlijentFizickoLiceAddVM x)
        {
            //UserController uc = new UserController(_logger, _userManager, _signInManager,
            //    _roleManager, _jwtConfig);
            try
            {
                if (!await _roleManager.RoleExistsAsync("Klijent"))
                {
                    return await Task.FromResult("Ne postoji rola za korisnika");
                }
                var user = new Korisnik
                {
                    UserName = x.KorisnickoIme,
                    EmailAdresa = x.Email,
                    BrojTelefona = x.BrojTelefona,
                    DatumDodavanja = DateTime.Now,
                    Adresa = x.Adresa,
                    Naziv = x.Ime + " "+x.Prezime,
                    isKlijentFizickoLice = true,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, x.Lozinka);
                if (result.Succeeded)
                {
                    var tempUser = await _userManager.FindByNameAsync(user.UserName);
                    await _userManager.AddToRoleAsync(tempUser, "Klijent");
                    var newKlijentFizickoLice = new KlijentFizickoLice
                    {
                        Ime = x.Ime,
                        Prezime = x.Prezime,
                        DatumRodjenja = x.DatumRodjenja,
                        Spol = x.Spol,
                        Aktivan = x.Aktivan,
                        ClanskaKartica = x.ClanskaKartica,
                        KorisnikID = user.Id
                    };
                    dBContext.Add(newKlijentFizickoLice);
                    dBContext.SaveChanges();
                    return await Task.FromResult(newKlijentFizickoLice);
                }
                return await Task.FromResult(string.Join(",", result.Errors.Select(
                    x => x.Description).ToArray()));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public ResponseModel GetKlijentFizickoById(string id)
        {
            try
            {
                if(id==null || id=="")
                {
                    return new ResponseModel(ResponseCode.Error,
                        "Korisnik nije pronađen", null);
                }
                var klijentFizicko = dBContext.KlijentiFizickoLice.
                    Where(k => k.KorisnikID == id).FirstOrDefault();
                if (klijentFizicko != null)
                {
                    return new ResponseModel(ResponseCode.OK,
                        "Klijent uspješno pronađen", klijentFizicko);
                }
                else
                {
                    return new ResponseModel(ResponseCode.Error,
                        "Klijent nije pronađen", null);
                }     

            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error,
                    ex.Message, null);
            }
        }
    }
}
