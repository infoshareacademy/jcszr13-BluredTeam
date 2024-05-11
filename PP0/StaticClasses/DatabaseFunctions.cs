using PP0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.StaticClasses
{
    internal static class DatabaseFunctions
    {
        internal static bool CheckAccess(List<User> users,string login, string pass)
        {
            return users.Any(x => x.Login.ToLower() == login.ToLower() && x.Password == pass);
        }
    }
}
