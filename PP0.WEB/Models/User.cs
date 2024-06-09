using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.WEB.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Role> Roles { get; set; }

        public User(string login, string password, List<Role> roles)
        {
            Login = login;
            Password = password;
            Roles = roles;
        }
    }

}
