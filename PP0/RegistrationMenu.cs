using PP0.Enums;
using PP0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0
{
    internal class RegistrationMenu
    {
        public static bool MainRegistrationMenu()
        {
            Console.Clear();
            Console.WriteLine($"Enter user details:");
            Console.Write("Enter login: ");
            string login = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Choose role (user, doctor, admin): ");
            List<Role> roles = UserRoleList();

            User newUser = new User(login, password, roles);
            return true;
        }



        public static List<Role> UserRoleList()
        {
            var _roles = new List<Role>();
            //var _role = new Role();
            //System.ConsoleKey key = Console.ReadKey().Key;

            foreach (RoleType item in RoleType.GetValues(typeof(RoleType)))
            {
                Console.Write($"add role {RoleType.GetName(item)} (press Y): ");
                System.ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y)
                {
                    //_role.Id = (int)item;
                    //_role.Name = (RoleType.GetName(item));
                    //_roles.Add(_role);
                    _roles.Add(new Role { Id = (int)item, Name = item.ToString() });
                }
                Console.WriteLine();
            }

            return _roles;
        }

    }
}
