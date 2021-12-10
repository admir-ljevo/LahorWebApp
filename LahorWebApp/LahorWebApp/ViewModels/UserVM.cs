using LahorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Views
{
    public class UserVM
    {
        public UserVM(Korisnik korisnik,string role)
        {
            this.Role = role;
            this.Korisnik = korisnik;
        }
        public Korisnik Korisnik { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
