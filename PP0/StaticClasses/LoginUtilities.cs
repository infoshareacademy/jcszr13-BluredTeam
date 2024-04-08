using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.StaticClasses
{
    internal static class LoginUtilities
    {
        /// <summary>
        /// This method pops up Main Menu. You can Login or Create New Account
        /// </summary>
        internal static void MainLoginRegisterWindow()
        {
            Console.Clear();
            Console.WriteLine($"Press 'L' for LOG INTO\nPress 'R' to REGISTER\nPress 'X' to abort");
        } 

        internal static void LoginCredentialsWindow()
        {
            bool nextStep;
            if (nextStep = ProvideYourCredential("Login"))
                if (nextStep = ProvideYourCredential("Password"))
                    if (nextStep = ProvideYourCredential("Role"))
                    {
                        Console.WriteLine("LOGGED SUCCESFULL!");
                        Console.ReadKey();
                    }
                    else
                        MainLoginRegisterWindow();

                else
                    MainLoginRegisterWindow();
            else
                MainLoginRegisterWindow();
            

        }

        internal static bool ProvideYourCredential(string credentailType)
        {
            Console.Clear();
            Console.WriteLine($"To go back to Main Login Window press 'Esc' Key.");
            Console.WriteLine($"Please provide your {credentailType}:");

            string input = "";

            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    return false;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{credentailType} provided: {input}");
                    Console.ReadKey();
                    return true;
                }
                else {
                    input += key.KeyChar;
                }
            }

        }



    }
}
