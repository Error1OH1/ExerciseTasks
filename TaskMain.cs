using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTasks
{
    public class TaskMain
    {
        public static void DisplayTask(string userName)
        {
            
            //calls user data
            string userjson = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json");
            dynamic userdata = JsonConvert.DeserializeObject(userjson);
            //calls task data
            string pushtaskjson = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\tasks\\pushUpstask.json");
            string sittaskjson = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\tasks\\sitUpstask.json");
            string jumptaskjson = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\tasks\\jumpingJackstask.json");
            dynamic pushtaskdata1 = JsonConvert.DeserializeObject(pushtaskjson);
            dynamic sittaskdata1 = JsonConvert.DeserializeObject(sittaskjson);
            dynamic jumptaskdata1 = JsonConvert.DeserializeObject(jumptaskjson);
            //Displays task in progress
            string directory = "C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Tasks";
            string[] files = Directory.GetFiles(directory, "*.json");

            foreach (string file in files)
            {
                string json = File.ReadAllText(file);
                dynamic data = JsonConvert.DeserializeObject(json);

                if (data.IsInProgress = true)
                {
                    Console.WriteLine("Level: "+ userdata.level + "\nXp Percentage: " + userdata.XPpercentage + "\nYour Task \n-=-=-=-=-=-=-=-=-=-=-=-=-\n" + "PushUps: " + data.Count * userdata.level + " XP: " + data.XP);
                    break;
                }
                else
                {
            //Displays Random task if one is not in progress
                    Random random = new Random();
                    int randomNumber = random.Next(1, 4);
                    switch (randomNumber)
                    {
                        case 1:
                            Console.WriteLine("Your Task \n-=-=-=-=-=-=-=-=-=-=-=-=-\n" + "PushUps: " + pushtaskdata1.Count * userdata.level + " XP: " + pushtaskdata1.XP);
                            pushtaskdata1.IsInProgress = true;
                            string pushupdate = JsonConvert.SerializeObject(pushtaskdata1);
                            File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\tasks\\pushUpstask.json", pushupdate);
                            break;
                        case 2:
                            Console.WriteLine("Your Task \n-=-=-=-=-=-=-=-=-=-=-=-=-\n" + "SitUps: " + sittaskdata1.Count * userdata.level + " XP: " + sittaskdata1.XP);
                            sittaskdata1.IsInProgress = true;
                            string SitUpdate = JsonConvert.SerializeObject(sittaskdata1);
                            File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\tasks\\sitUpstask.json", SitUpdate);
                            break;
                        case 3:
                            Console.WriteLine("Your Task \n-=-=-=-=-=-=-=-=-=-=-=-=-\n" + "JumpingJacks: " + jumptaskdata1.Count * userdata.level + " XP: " + jumptaskdata1.XP);
                            jumptaskdata1.IsInProgress = true;
                            string JumpUpdate = JsonConvert.SerializeObject(jumptaskdata1);
                            File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\tasks\\jumpingJackstask.json", JumpUpdate);
                            break;
                    }


                }
            }
                TaskUserOptions.MainPrompt(userName);
        }
    }
}
