using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExerciseTasks;

public class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public int level = 0;
    public int XPpercentage = 0;
}

public class UserLogin
{
    public static string Userlogin()
    {
        string DirectoryCheck = "C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\";
        bool fileExist = Directory.GetFiles(DirectoryCheck).Length > 0;
        if (!fileExist)
        {
            Console.WriteLine("No Profiles exist on this device, you must create a new User.\n(Press any Key to continue.)");
            Console.ReadKey(true);
            Console.Clear();
            UserAccessMenu.Prompt();
        }
        Console.Write("Username:");

        string userName = Console.ReadLine() ?? "";
        if (userName == null)
        {
            Console.Clear();
            Console.WriteLine("You must enter a valid username");
            Console.ReadKey(true);
            Console.Clear();
            return Userlogin();
        }
        if (!File.Exists("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json"))
        {
            Console.Clear();
            Console.WriteLine("User Name Does not exist");
            Console.ReadKey(true);
            Console.Clear();
            return Userlogin();
        }
        else
        {
            string json = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json");
            dynamic data = JsonConvert.DeserializeObject(json);
            Console.Write("Password:");
            string passWord = Console.ReadLine();
            if (data.Password != passWord)
            {
                Console.Clear();
                return Userlogin();
            }
            else
            {
                Console.Clear();
                return userName;
            }
        }
    }
}

public class UserCreation
{
    public static string UserCreationPrompt()
    {
        
        Console.WriteLine("What is your name?");

        string? userName = Console.ReadLine();
        //If user does not enter anything it will clear and tell them 
        if (userName == null)
        {
            Console.Clear();
            Console.WriteLine("You must enter a valid username");
            Console.ReadKey(true);
            Console.Clear();
            UserCreationPrompt();
        }
        //If the username has already been used then it will tell them
        if (File.Exists("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json"))
        {
            Console.Clear();
            Console.WriteLine("User Name is already in use, you must pick another one");
            Console.ReadKey(true);
            Console.Clear();
            UserCreationPrompt();
        }
        Console.WriteLine("What would you like your password to be?");
        string? passWord = Console.ReadLine();

        User user = new User
        {
            Name = userName,
            Password = passWord
        };
        string json = JsonConvert.SerializeObject(user);

        File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json", json);

        Console.Clear();
        return userName;


    }
}
