using PP0.Models;
using PP0.Services;
using PP0.StaticClasses;

namespace PP0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool stayInMainMenu = true;
            do
            {
                LoginUtilities.MainLoginRegisterWindow();
                System.ConsoleKey key = Console.ReadKey().Key;

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
                else if (key == ConsoleKey.X)
                {
                    stayInMainMenu = false;
                }

            } while (stayInMainMenu);
       
      

 

            var fileService = new FileServices();

            var users = new List<User>();

            var newUser = new User();

            fileService.SaveIntoBinDirectory(newUser);

            Console.WriteLine("Użytkownik został zapisany do pliku: ");

            Display(fileService.LoadFromBinDirectory());

            Console.WriteLine("Odczytano plik");
            Console.ReadKey();
        }

            static void Display(List<User> users)

        {
            foreach (var user in users)
            {

                Console.WriteLine();
                Console.WriteLine($"\tLogin: {user.Login}, Password: {user.Password}, Role: {user.Roles}, ");
                Console.WriteLine();
            }
        }
    }
}