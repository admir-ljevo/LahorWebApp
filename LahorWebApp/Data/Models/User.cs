using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        public User(string username,string email,string adresa,string brojtelefona)
        {
            this.userName = username;
            this.email = email;
            this.adresa = adresa;
            this.brojTelefona = brojtelefona;
        }
        public string userName { get; set; }
        public string email { get; set; }
        public string adresa { get; set; }
        public string brojTelefona { get; set; }
    }
}
