using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Views
{
    public class UpravnoOsobljeAddVM
    {
        public string Titula { get; set; }
        public int PozicijaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }
        public string StrucnaSprema { get; set; }
        public string MjestoRodjenja { get; set; }
        public string MjestoPrebivalista { get; set; }
        public int SpolId { get; set; }
        public int BracniStatusID { get; set; }
        public string Nacionalost { get; set; }
        public string Drzavljanstvo { get; set; }
        public bool RadnoIskustvo { get; set; }
        public string Biografija { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public int VozackaKategorijaId { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public float IznosPlate { get; set; }
        public bool Aktivan { get; set; }
    }
}
