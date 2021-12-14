using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Radnik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }
        public string StrucnaSprema { get; set; }
        public string MjestoRodjenja { get; set; }
        public string MjestoPrebivalista { get; set; }
        public Spol Spol { get; set; }
        public int SpolID { get; set; }
        public BracniStatus BracniStatus { get; set; }
        public int BracniStatusID { get; set; }
        public string Nacionalost { get; set; }
        public string Drzavljanstvo { get; set; }
        public byte[] Slika { get; set; }
        public bool RadnoIskustvo { get; set; }
        public string Biografija { get; set; }
        public Pozicija Pozicija { get; set; }
        public int PozicijaID { get; set; }
        public VoazckaDozvolaKategorija VoazckaDozvolaKategorija { get; set; }
        public int VoazckaDozvolaKategorijaID { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string IznosPlate { get; set; }
        public bool Aktivan { get; set; }
    }
}
