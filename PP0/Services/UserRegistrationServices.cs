using PP0.Models;
using System.Collections.Generic;

namespace PP0.Services
{
    internal static class UserRegistrationServices
    {
        private static List<User> _users = new List<User>();

        public static void SetAllUsers(List<User> users) { _users = users; }

        public static List<User> GetAllUsers() { return _users; }


        public static User? GetUserByLogin(string login)
        {

            foreach (var user in _users)
            {
                if (user.Login == login)
                {
                    return user;
                }
            }

            return null;
        }

        public static bool CreateNewAccount(User user)
        {
            if (_users.Count == 0 || GetUserByLogin(user.Login) is null)
            {
                _users.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ValidateNewAccount(User user)
        {
            if (user.Login == null || user.Password == null || user.Roles == null)
            {
                return $"incorrect data";
            }
            else
            {
                return $"correct data";
            }
        }

    }
}
