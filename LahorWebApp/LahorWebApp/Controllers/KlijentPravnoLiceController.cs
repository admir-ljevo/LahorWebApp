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
    public class KlijentPravnoLiceController : ControllerBase
    {
        private readonly LahorAppDBContext dBContext;

        public KlijentPravnoLiceController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        //[HttpPost]

        //public KlijentPravnoLice Add(KlijentPravnoLiceAddVM x)
        //{
        //    var newKlijentPravnoLice = new KlijentPravnoLice
        //    {
        //        NazivKlijenta = x.NazivKlijenta,
        //        IdBrojFirme = x.IdBrojFirme,
        //        BrojTelefona = x.BrojTelefona,
        //        Email = x.Email,
        //        Aktivan = x.Aktivan,
        //        ClanskaKartica = x.ClanskaKartica,
        //        DatumDodavanja = x.DatumDodavanja,
        //        Adresa = x.Adresa,
        //        Lozinka = x.Lozinka,
        //        KorisnickoIme = x.KorisnickoIme
        //    };
        //    dBContext.Add(newKlijentPravnoLice);
        //    dBContext.SaveChanges();
        //    return newKlijentPravnoLice;
        //}
    }
}

