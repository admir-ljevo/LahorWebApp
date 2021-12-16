using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Uposlenici")]
    public class Uposlenik:Radnik
    {
        public int Id { get; set; }
        public string Zanimanje { get; set; }

        public Korisnik Korisnik { get; set; }
        public string KorisnikID { get; set; }
    }
}
