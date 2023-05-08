using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTasks
{
    public class TaskUserOptions
    {
        public static void MainPrompt(string userName)
        {
            if (userName == "test")
            {
                TestingOptions(userName);
            }
            else
            {
                Console.WriteLine("Type 'Complete' to Complete the task");
                string response = Console.ReadLine().ToLower();

                switch (response)
                {
                    case "complete":
                        Console.Clear();
                        TaskUserOptions.CompleteTask(userName);
                        break;

                }
            }
        }
        public static void CompleteTask(string userName)
        {

            Console.WriteLine(userName + " Are you sure you would like to mark this task complete?");
            string response = Console.ReadLine().ToLower();
            if (response == "y" || response == "yes")
            {
                string TaskSearch = "C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Tasks";
                string[] files = Directory.GetFiles(TaskSearch, "*.json");

                foreach (string file in files)
                {
                    string json = File.ReadAllText(file);
                    dynamic data = JsonConvert.DeserializeObject(json);

                    if (data.IsInProgress == true)
                    {
                        data.IsInProgress = false;

                        string jsonupdate = JsonConvert.SerializeObject(data);

                        File.WriteAllText(file, jsonupdate);


                        string userjson = "C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json";
                        dynamic userdata = JsonConvert.DeserializeObject(userjson);
                        userdata.XPpercentage += 2;
                        string userupdate = JsonConvert.SerializeObject(userdata);
                        File.WriteAllText(userjson, userupdate);
                        LevelSystem.levelSystem(userName);





                    }


                }
                Console.Clear();
                TaskMain.DisplayTask(userName);
            }
            if (response == "n" || response == "no")
            {
                TaskMain.DisplayTask(userName);
            }


        }
        
        public static void TestingOptions(string userName)
        {
            Console.WriteLine("Press 1 to Level up | Press 2 to lower level | Press 3 to Complete Task");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                switch(key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        string json = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json");
                        dynamic data = JsonConvert.DeserializeObject(json);
                        data.level++;
                        string update = JsonConvert.SerializeObject(data);
                        File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\test.json", update);
                        TaskMain.DisplayTask(userName);
                        break;

                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        string json2 = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json");
                        dynamic data2 = JsonConvert.DeserializeObject(json2);
                        data2.level += 1;
                        string update2 = JsonConvert.SerializeObject(data2);
                        File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\test.json", update2);
                        TaskMain.DisplayTask(userName);
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        string json3 = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json");
                        dynamic data3 = JsonConvert.DeserializeObject(json3);
                        data3.level -= 1;
                        string update3 = JsonConvert.SerializeObject(data3);
                        File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\test.json", update3);

                        TaskMain.DisplayTask(userName);
                        break;

                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        string json4 = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json");
                        dynamic data4 = JsonConvert.DeserializeObject(json4);
                        data4.level -= 1;
                        string update4 = JsonConvert.SerializeObject(data4);
                        File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\test.json", update4);
                        TaskMain.DisplayTask(userName);
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        TaskUserOptions.CompleteTask(userName);
                        break;

                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        TaskUserOptions.CompleteTask(userName);
                        break;
                }

            }
            while (key != ConsoleKey.D1 && key != ConsoleKey.NumPad1 && key != ConsoleKey.NumPad2 && key != ConsoleKey.D2 && key != ConsoleKey.D3 && key != ConsoleKey.NumPad3);

            return;
        }
    }
}
