using PP0.StaticClasses;

namespace PP0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool exitMainMenu = false;
            do
            { 
                LoginUtilities.MainLoginRegisterWindow();
                System.ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.L)
                {
                    LoginUtilities.LoginCredentialsWindow();
                }
                else if (key == ConsoleKey.R) {
                    Console.WriteLine("Show Registration Window");
                }
                else if (key == ConsoleKey.X)
                {
                    exitMainMenu = true;
                }

            } while (!exitMainMenu);
            
        }
    }
}
