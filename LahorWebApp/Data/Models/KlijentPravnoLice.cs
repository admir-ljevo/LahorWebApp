using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Models
{
    [Table("KlijentiPravnoLice")]
    public class KlijentPravnoLice:Klijent
    {
        public int Id { get; set; }
        public string NazivKlijenta { get; set; }
        public string IdBrojFirme { get; set; }

        public Korisnik Korisnik { get; set; }
        public string KorisnikID { get; set; }
    }
}
