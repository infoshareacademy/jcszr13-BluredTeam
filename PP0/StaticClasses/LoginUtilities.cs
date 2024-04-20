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
            Console.WriteLine($"Press 'L' for LOG INTO\nPress 'R' to REGISTER\nPress 'V' to CREATE VISIT\nPress 'X' to abort");
        } 

        internal static bool LoginCredentialsWindow()
        {
            bool nextStep;
            string? output;
            
            if (nextStep = ProvideYourCredential("Please provide Login",out output))
            {
                if (nextStep = ProvideYourCredential("Please provide Password", out output))
                {
                    Console.WriteLine("LOGGED SUCCESFULL!");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
                
            

        }

        internal static bool CreateNewAccountWindow() {
            bool nextStep;
            string? output;
            if (nextStep = ProvideYourCredential(@"Please provide Login\Account Name", out output))
                if (nextStep = ProvideYourCredential("Please provide Password", out output))
                    if (nextStep = ProvideYourCredential("Please confirm Password", out output))
                        if (nextStep = ProvideYourCredential("Please provide Role", out output))
                         {
                            Console.WriteLine("ACCOUNT CREATED!");
                            Console.ReadKey();
                            return true;
                            }
                        else
                            return false;
                    else return false;
                else
                    return false;
            else
                return false;
        }

        internal static bool ProvideYourCredential(string credentailType, out string? output)
        {
            Console.Clear();
            Console.WriteLine($"To go back to Main Login Window press 'Esc' Key.");
            Console.WriteLine($"{credentailType}:");

            string input = "";

            while(true)
            {
                
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    output = null;
                    return false;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{credentailType} provided: {input}");
                    
                    Console.ReadKey();
                    output = input;
                    return true;
                }
                else {
                    input += key.KeyChar;
                }
            }

        }



    }
}
