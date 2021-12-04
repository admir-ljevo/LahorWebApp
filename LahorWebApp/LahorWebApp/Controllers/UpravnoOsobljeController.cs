using LahorWebApp.Data;
using LahorWebApp.Models;
using LahorWebApp.Views;
using Microsoft.AspNetCore.Mvc;
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

        public UpravnoOsobljeController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpPost]

        public UpravnoOsoblje Add(UpravnoOsobljeAddVM x)
        {
            var newUpravnoOsoblje = new UpravnoOsoblje
            {
                Titula = x.Titula,
                Pozicija = x.Pozicija,
                Ime = x.Ime,
                Prezime = x.Prezime,
                DatumRodjenja = x.DatumRodjenja,
                JMBG = x.JMBG,
                StrucnaSprema = x.StrucnaSprema,
                MjestoRodjenja = x.MjestoRodjenja,
                MjestoPrebivalista = x.MjestoPrebivalista,
                Spol = x.Spol,
                BracniStatus = x.BracniStatus,
                Nacionalost = x.Nacionalost,
                Drzavljanstvo = x.Drzavljanstvo,
                RadnoIskustvo = x.RadnoIskustvo,
                Biografija = x.Biografija,
                BrojTelefona = x.BrojTelefona,
                Email = x.Email,
                KorisnickoIme = x.KorisnickoIme,
                Lozinka = x.Lozinka,
                VoazckaDozvolaKategorija = x.VoazckaDozvolaKategorija,
                DatumZaposlenja = x.DatumZaposlenja,
                IznosPlate = x.IznosPlate,
                Aktivan = x.Aktivan
            };
            dBContext.Add(newUpravnoOsoblje);
            dBContext.SaveChanges();
            return newUpravnoOsoblje;
        }
    }
}
