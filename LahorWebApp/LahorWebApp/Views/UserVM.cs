using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Views
{
    public class UserVM
    {
        public UserVM(string username,string email,string role)
        {
            this.Username = username;
            this.Email = email;
            this.Role = role;
        }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
