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
           
            

        }
    }
}
