using PP0.Models;
using PP0.Services;
using PP0.StaticClasses;
using System;
using System.Collections.Generic;

namespace PP0
{
    internal class Program
    {
        internal static List<User> users;
        static void Main(string[] args)
        {
            users = OperationsWithJson.DeserilizeJson<User>(@"Files\UsersDb.json");
            
            bool stayInMainMenu = true;
            bool goToNextScreen = false;
            do
            {
                LoginUtilities.MainLoginRegisterWindow();
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.L)
                {
                    (stayInMainMenu, goToNextScreen) = LoginUtilities.LoginCredentialsWindow();
                    stayInMainMenu = !stayInMainMenu;
                    continue;
                }
                else if (key == ConsoleKey.R)
                {
                    var prepUser = RegistrationMenu.MainRegistrationMenu();
                                        
                    UserRegistrationServices.SetAllUsers(users);
                    UserRegistrationServices.CreateNewAccount(prepUser.user);
                    users = UserRegistrationServices.GetAllUsers();
                    OperationsWithJson.SerializeToJson(users, @"Files\UsersDb.json");

                    stayInMainMenu = prepUser.stayInMainMenu;
                    continue;
                }
                else if (key == ConsoleKey.V)
                {
                    var result = VisitUtilities.CreateNewVisit();
                    //TODO: Zapis result.visit do pliku
                    stayInMainMenu = !result.stayInMainMenu;
                    continue;
                }
                else if (key == ConsoleKey.X)
                {
                    stayInMainMenu = false;
                }

            } while (stayInMainMenu);



        }
    }
}
