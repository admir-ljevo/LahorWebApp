using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Models
{
    public class Klijent
    {
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public  bool Aktivan { get; set; }
        public bool  ClanskaKartica { get; set; }
        public string DatumDodavanja { get; set; }
        public string Adresa{ get; set; }
        public string Lozinka { get; set; }
        public string KorisnickoIme { get; set; }
    }
}
