using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Models
{
    public class Korisnik
    {
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
        public byte[] Slika { get; set; }
        public bool RadnoIskustvo { get; set; }
        public string Biografija { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public virtual VoazckaDozvolaKategorija VoazckaDozvolaKategorija { get; set; }
        public string DatumZaposlenja { get; set; }
        public string IznosPlate { get; set; }
        public bool Aktivan { get; set; }

    }
}
