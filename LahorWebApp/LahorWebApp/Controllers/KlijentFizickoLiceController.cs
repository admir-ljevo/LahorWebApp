using LahorWebApp.Data;
using LahorWebApp.Models;
using LahorWebApp.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public KlijentFizickoLiceController(LahorAppDBContext dBContext,
            UserManager<Korisnik> userManager)
        {
            this.dBContext = dBContext;
            _userManager = userManager;
        }
        [HttpPost]

        public KlijentFizickoLice Add(KlijentFizickoLiceAddVM x)
        {
            var korisnik = new Korisnik
            {
                BrojTelefona=x.BrojTelefona,
                EmailAdresa=x.Email,
                UserName=x.KorisnickoIme,
                Adresa=x.Adresa,
                DatumDodavanja=DateTime.Now
            };
            string password = "AAzzzBB123/";
            IdentityResult result = _userManager.CreateAsync(korisnik, password).Result;

            //string confirmationToken = _userManager.
            //    GenerateEmailConfirmationTokenAsync(korisnik).Result;
            var newKlijentFizickoLice = new KlijentFizickoLice
           {
               Ime = x.Ime,
               Prezime = x.Prezime,
               DatumRodjenja = x.DatumRodjenja,
               Spol = x.Spol,
               Aktivan = x.Aktivan,
               ClanskaKartica = x.ClanskaKartica,
               KorisnikID=korisnik.Id
           };
            dBContext.Add(newKlijentFizickoLice);
            dBContext.SaveChanges();
           return newKlijentFizickoLice;
        }
    }
}
