using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Models
{
    [Table("UpravnoOsoblje")]
    public class UpravnoOsoblje:Radnik
    {
        public int Id { get; set; }
        public string Titula { get; set; }

        public Korisnik Korisnik { get; set; }
        public string KorisnikID { get; set; }
    }
}
