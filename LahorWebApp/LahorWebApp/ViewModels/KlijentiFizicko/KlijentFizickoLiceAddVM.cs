using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Views
{
    public class KlijentFizickoLiceAddVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }
        public Spol Spol { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public bool Aktivan { get; set; }
        public bool ClanskaKartica { get; set; }
        public string DatumDodavanja { get; set; }
        public string Adresa { get; set; }
        public string Lozinka { get; set; }
        public string KorisnickoIme { get; set; }
    }
}
