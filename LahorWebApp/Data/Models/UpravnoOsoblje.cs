using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("UpravnoOsoblje")]
    public class UpravnoOsoblje:Radnik
    {
        [Key]
        public int Id { get; set; }
        public string Titula { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public string KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
