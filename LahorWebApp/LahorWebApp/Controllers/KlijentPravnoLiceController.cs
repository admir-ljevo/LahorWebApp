using Data.Data;
using Data.Enum;
using Data.Helpers;
using Data.Models;
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
    public class KlijentPravnoLiceController : ControllerBase
    {
        private readonly LahorAppDBContext dBContext;
        private UserManager<Korisnik> _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly SignInManager<Korisnik> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<JWTConfig> _jwtConfig;

        public KlijentPravnoLiceController(
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
        public async Task<object> Add(KlijentPravnoLiceAddVM x)
        {
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
                    Slika = Config.SlikeURL + "empty.png",
                    Adresa = x.Adresa,
                    Naziv = x.NazivKlijenta,
                    isKlijentPravnoLice = true,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, x.Lozinka);
                if (result.Succeeded)
                {
                    var tempUser = await _userManager.FindByNameAsync(user.UserName);
                    await _userManager.AddToRoleAsync(tempUser, "Klijent");
                    var newKlijentPravnoLice = new KlijentPravnoLice
                    {
                        IdBrojFirme=x.IdBrojFirme,
                        NazivKlijenta=x.NazivKlijenta,
                        Aktivan = x.Aktivan,
                        ClanskaKartica = x.ClanskaKartica,
                        KorisnikID = user.Id
                    };
                    dBContext.Add(newKlijentPravnoLice);
                    dBContext.SaveChanges();
                    return await Task.FromResult(new ResponseModel(
                        ResponseCode.OK,"Klijent uspješno dodan",newKlijentPravnoLice));
                }
                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error,"Korisnik nije pronađen",null));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error, "Greška-> "+ex.Message+" "+
                    ex.InnerException, null));
            }
        }
    }
}

