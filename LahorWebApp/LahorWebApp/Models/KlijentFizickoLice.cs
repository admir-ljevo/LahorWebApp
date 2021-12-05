using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Models
{
    [Table("KlijentiFizickoLice")]
    public class KlijentFizickoLice:Klijent
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }
        public Spol  Spol { get; set; }
        public int SpolID { get; set; }

        public Korisnik Korisnik { get; set; }
        public string KorisnikID { get; set; }
    }
}
