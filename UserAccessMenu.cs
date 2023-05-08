using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTasks
{
    public class UserAccessMenu
    {
        public static string Prompt()
        {
            Console.WriteLine("Press 1 to Create a Profile | Press 2 to Login");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        string UsernameReturn1 = UserCreation.UserCreationPrompt();
                        return UsernameReturn1;

                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        string UsernameReturn2 = UserCreation.UserCreationPrompt();
                        return UsernameReturn2;

                    case ConsoleKey.D2:
                        Console.Clear();
                        string UsernameReturn3 = UserLogin.Userlogin();
                        return UsernameReturn3;

                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        string UsernameReturn4 = UserLogin.Userlogin();
                        return UsernameReturn4;

                }

            }
            while (key != ConsoleKey.D1 && key != ConsoleKey.NumPad1 && key != ConsoleKey.NumPad2 && key != ConsoleKey.D2);

            return "error";
        }
    }
}
