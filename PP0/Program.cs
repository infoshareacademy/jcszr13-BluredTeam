using PP0.Models;
using PP0.StaticClasses;
using System;

namespace PP0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var users = OperationsWithJson.DeserilizeJson<User>(@"Files\UsersDb.json");
            
            bool stayInMainMenu = true;
            do
            {
                LoginUtilities.MainLoginRegisterWindow();
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.L)
                {
                    stayInMainMenu = !LoginUtilities.LoginCredentialsWindow();
                    continue;
                }
                else if (key == ConsoleKey.R)
                {
                    stayInMainMenu = !LoginUtilities.CreateNewAccountWindow();
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
