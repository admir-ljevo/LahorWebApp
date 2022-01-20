using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Narudzbe")]
    public class Narudzba
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public bool Isporucena { get; set; }
        public float UkupnaCijena { get; set; }
        public float Kolicina { get; set; }
        public string Opis { get; set; }
        public string NazivKlijenta { get; set; }
        //public UpravnoOsoblje AutorUpravno { get; set; }
        //public Uposlenik AutorUposlenik { get; set; }

        //[ForeignKey(nameof(Radnik))]
        //public int RadnikId { get; set; }
        public Radnik Radnik { get; set; }

        [ForeignKey(nameof(Klijent))]
        public int KlijentId { get; set; }
        public Klijent Klijent { get; set; }
        //public KlijentFizickoLice KlijentFizickoLice { get; set; }
        //public KlijentPravnoLice KlijentPravnoLice { get; set; }
        public bool isOnline { get; set; }
        public bool isGuest { get; set; }
        public bool isNarudzbaAutor { get; set; }
        public IList<IzvjestajiNarudzbe> IzvjestajiNarudzbe { get; set; }
    }
}
