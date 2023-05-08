// LFInteractive LLC. - All Rights Reserved
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExerciseTasks
{
    public class TaskMain
    {
        public static void DisplayTask(string userName)
        {
            string working_directory = Directory.CreateDirectory(Path.GetFullPath("./env")).FullName;
            string tasks_directory = Directory.CreateDirectory(Path.Combine(working_directory, "tasks")).FullName;
            string saved_tasks_directory = Directory.CreateDirectory(Path.Combine(tasks_directory, "saved")).FullName;

            //calls user data
            string userjson = File.ReadAllText(Path.Combine(working_directory, $"{userName}.json"));
            dynamic userdata = JsonConvert.DeserializeObject(userjson);
            //calls task data
            string pushtaskjson = File.ReadAllText(Path.Combine(tasks_directory, "pushUpstask.json"));
            string sittaskjson = File.ReadAllText(Path.Combine(tasks_directory, "sitUpstask.json"));
            string jumptaskjson = File.ReadAllText(Path.Combine(tasks_directory, "jumpingJackstask.json"));

            PushUps pushtaskdata1 = JObject.Parse(pushtaskjson).ToObject<PushUps>();
            dynamic sittaskdata1 = JsonConvert.DeserializeObject(sittaskjson);
            dynamic jumptaskdata1 = JsonConvert.DeserializeObject(jumptaskjson);
            //Displays task in progress
            string directory = saved_tasks_directory;
            string[] files = Directory.GetFiles(directory, "*.json");

            foreach (string file in files)
            {
                string json = File.ReadAllText(file);
                ITaskItem data = JObject.Parse(json).ToObject<ITaskItem>();

                if (data.IsInProgress == true)
                {
                    Console.WriteLine("Level: " + userdata.level + "\nXp Percentage: " + userdata.XPpercentage + "\nYour Task \n-=-=-=-=-=-=-=-=-=-=-=-=-\n" + "PushUps: " + data.Count * userdata.level + " XP: " + data.XP);
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
                            File.WriteAllText(Path.Combine(tasks_directory, "pushUpstask.json"), pushupdate);
                            break;

                        case 2:
                            Console.WriteLine("Your Task \n-=-=-=-=-=-=-=-=-=-=-=-=-\n" + "SitUps: " + sittaskdata1.Count * userdata.level + " XP: " + sittaskdata1.XP);
                            sittaskdata1.IsInProgress = true;
                            string SitUpdate = JsonConvert.SerializeObject(sittaskdata1);
                            File.WriteAllText(Path.Combine(tasks_directory, "sitUpstask.json"), SitUpdate);
                            break;

                        case 3:
                            Console.WriteLine("Your Task \n-=-=-=-=-=-=-=-=-=-=-=-=-\n" + "JumpingJacks: " + jumptaskdata1.Count * userdata.level + " XP: " + jumptaskdata1.XP);
                            jumptaskdata1.IsInProgress = true;
                            string JumpUpdate = JsonConvert.SerializeObject(jumptaskdata1);
                            File.WriteAllText(Path.Combine(tasks_directory, "jumpingJackstask.json"), JumpUpdate);
                            break;
                    }
                }
            }
            TaskUserOptions.MainPrompt(userName);
        }
    }
}