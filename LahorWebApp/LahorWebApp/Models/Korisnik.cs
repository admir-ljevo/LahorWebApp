using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }
        public string JMBG { get; set; }
        public string StrucnaSprema { get; set; }
        public string MjestoRodjenja { get; set; }
        public string MjestoPrebivalista { get; set; }

        public virtual Spol Spol { get; set; }

        public virtual BracniStatus BracniStatus { get; set; }

        public string Nacionalost { get; set; }
        public string Drzavljanstvo { get; set; }

    }
}
