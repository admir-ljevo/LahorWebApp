using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Models
{
    [Table("Uposlenici")]
    public class Uposlenik:Korisnik
    {
        public int Id { get; set; }
        public string Zanimanje { get; set; }
        public string Pozicija { get; set; }
    }
}
