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
    public class UpravnoOsobljeController : ControllerBase
    {
        private readonly LahorAppDBContext dBContext;
        private UserManager<Korisnik> _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly SignInManager<Korisnik> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<JWTConfig> _jwtConfig;

        public UpravnoOsobljeController(
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
        public async Task<object> Add([FromBody] UpravnoOsobljeAddVM x)
        {
            //UserController uc = new UserController(_logger, _userManager, _signInManager,
            //    _roleManager, _jwtConfig);
            try
            {
                if (!await _roleManager.RoleExistsAsync("UpravnoOsoblje"))
                {
                    return await Task.FromResult(new ResponseModel(
                        ResponseCode.Error, "Ne postoji rola", null));
                }
                var user = new Korisnik
                {
                    UserName = x.KorisnickoIme,
                    EmailAdresa = x.Email,
                    BrojTelefona = x.BrojTelefona,
                    DatumDodavanja = DateTime.Now,
                    Slika = Config.SlikeURL + "empty.png",
                    Adresa = x.Adresa,
                    Naziv = x.Ime + " " + x.Prezime,
                    isUpravnoOsoblje = true,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, x.Lozinka);
                if (result.Succeeded)
                {
                    var tempUser = await _userManager.FindByNameAsync(user.UserName);
                    await _userManager.AddToRoleAsync(tempUser, "UpravnoOsoblje");
                    var newUpravnoOsoblje = new UpravnoOsoblje
                    {
                        Ime = x.Ime,
                        Prezime = x.Prezime,
                        DatumRodjenja = x.DatumRodjenja,
                        SpolID = x.SpolId,
                        Aktivan = x.Aktivan,
                        Titula = x.Titula,
                        PozicijaId = x.PozicijaId,
                        JMBG = x.JMBG,
                        StrucnaSprema = x.StrucnaSprema,
                        MjestoRodjenja = x.MjestoRodjenja,
                        MjestoPrebivalista = x.MjestoPrebivalista,
                        BracniStatusID = x.BracniStatusID,
                        Nacionalost = x.Nacionalost,
                        Drzavljanstvo = x.Drzavljanstvo,
                        RadnoIskustvo = x.RadnoIskustvo,
                        Biografija = x.Biografija,
                        VoazckaDozvolaKategorijaID = x.VozackaKategorijaId,
                        DatumZaposlenja = x.DatumZaposlenja,
                        IznosPlate = x.IznosPlate,
                        KorisnikID = user.Id
                    };
                    dBContext.Add(newUpravnoOsoblje);
                    dBContext.SaveChanges();
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK,
                        "Upravno osoblje zaposlenik uspješno dodan", newUpravnoOsoblje));
                }
                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error, "Korisnik nije kreiran", null));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(new ResponseModel(
                    ResponseCode.Error, "Greška -> " + ex.Message, null));
            }
        }

        [HttpGet("{id}")]
        public ResponseModel getUpravnoOsobljeById(string id)
        {
            try
            {
                    var upravnoOsoblje = dBContext.UpravnoOsoblje.Where(uo =>
                      uo.KorisnikID == id).FirstOrDefault();

                    if (upravnoOsoblje != null)
                        return new ResponseModel(ResponseCode.OK,
                            "Upravno osoblje uposlenik uspješno preuzet", upravnoOsoblje);
                    else
                    {
                        return new ResponseModel(ResponseCode.Error,
                   "Upravno osoblje uposlenik nije pronađen", null);
                    }
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error,
                    "Korisnik nije preuzet"+ ex.InnerException, null);
            }
        }
    }
}
