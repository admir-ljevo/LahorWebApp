using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Radnici")]
    public class Radnik
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }
        public string StrucnaSprema { get; set; }
        public string MjestoRodjenja { get; set; }
        public string MjestoPrebivalista { get; set; }

        [ForeignKey(nameof(Spol))]
        public int SpolID { get; set; }
        public Spol Spol { get; set; }

        [ForeignKey(nameof(BracniStatus))]
        public int BracniStatusID { get; set; }
        public BracniStatus BracniStatus { get; set; }
        public string Nacionalost { get; set; }
        public string Drzavljanstvo { get; set; }
        public string Slika { get; set; }
        public bool RadnoIskustvo { get; set; }
        public string Biografija { get; set; }

        [ForeignKey(nameof(Pozicija))]
        public int PozicijaId { get; set; }
        public Pozicija Pozicija { get; set; }

        [ForeignKey(nameof(VozackaDozvolaKategorija))]
        public int VoazckaDozvolaKategorijaID { get; set; }
        public VozackaDozvolaKategorija VozackaDozvolaKategorija { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public float IznosPlate { get; set; }
        public bool Aktivan { get; set; }
    }
}
