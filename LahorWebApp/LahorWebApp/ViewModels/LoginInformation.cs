using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.ViewModels
{
    public class LoginInformation
    {
        public LoginInformation(Korisnik korisnik, string role)
        {
            this.KorisnikId = korisnik.Id;
            this.Role = role;
            this.Naziv = korisnik.Naziv;
            //this.SlikaKorisnika = korisnik.Slika;
        }
        public string KorisnikId { get; set; }
        public string Naziv { get; set; }
        public string SlikaKorisnika { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
