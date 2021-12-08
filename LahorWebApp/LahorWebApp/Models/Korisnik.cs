using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Models
{
    [Table("Korisnici")]
    public class Korisnik:IdentityUser
    {
        public string EmailAdresa { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public string Adresa { get; set; }

        //public Uposlenik Uposlenik { get; set; }
        //public int UposlenikID { get; set; }

        //public UpravnoOsoblje UpravnoOsoblje { get; set; }
        //public int UpravnoOsobljeID { get; set; }

        //public KlijentPravnoLice KlijentPravnoLice { get; set; }
        //public int KlijentPravnoLiceID { get; set; }

        //public KlijentFizickoLice KlijentFizickoLice { get; set; }
        //public int KlijentFizickoLiceID { get; set; }

        //public bool isUposlenik { get; set; }
        //public bool isUpravnoOsoblje { get; set; }
        //public bool isKlijentPravnoLice { get; set; }
        //public bool isKlijentFizickoLice { get; set; }
        //public bool isAdmin { get; set; }

    }
}
