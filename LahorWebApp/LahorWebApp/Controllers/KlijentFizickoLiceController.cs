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
    public class KlijentFizickoLiceController : ControllerBase
    {
        private readonly LahorAppDBContext dBContext;

        public KlijentFizickoLiceController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        //[HttpPost]

        //public KlijentFizickoLice Add(KlijentFizickoLiceAddVM x)
        //{
        //    var newKlijentFizickoLice = new KlijentFizickoLice
        //    {
        //        Ime = x.Ime,
        //        Prezime = x.Prezime,
        //        DatumRodjenja = x.DatumRodjenja,
        //        Spol = x.Spol,
        //        BrojTelefona = x.
        //        Email = x.Email,
        //        Aktivan = x.Aktivan,
        //        ClanskaKartica = x.ClanskaKartica,
        //        DatumDodavanja = x.DatumDodavanja,
        //        Adresa = x.Adresa,
        //        Lozinka = x.Lozinka,
        //        KorisnickoIme = x.KorisnickoIme
        //    };
        //    dBContext.Add(newKlijentFizickoLice);
        //    dBContext.SaveChanges();
        //    return newKlijentFizickoLice;
        //}
    }
}
