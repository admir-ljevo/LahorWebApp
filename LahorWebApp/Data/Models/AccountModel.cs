using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class AccountModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string Role { get; set; }
    }
}
