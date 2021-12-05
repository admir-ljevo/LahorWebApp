using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Views
{
    public class UserVM
    {
        public UserVM(string username,string email)
        {
            this.Username = username;
            this.Email = email;
        }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
