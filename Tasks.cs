using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTasks;

    public class Tasks
{
    public static async Task GenerateTasksEnvironment()
    {

        PushUps pushUpstask = new PushUps();
        SitUps sitUpstask = new SitUps();
        JumpingJacks jumpingJackstask = new JumpingJacks();
        User user = new User()
        {
            Name = "test",
            Password = "123"
            
        };
        if (!Directory.Exists("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\"))
        {
            Directory.CreateDirectory("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\");
        }
        if (!File.Exists("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\test.json"))
        {
            string json = JsonConvert.SerializeObject(user);
            await Task.Run(() => File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\test.json", json));            
        }
        if (!Directory.Exists("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Tasks\\"))
        {
            Directory.CreateDirectory("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Tasks\\");
        }
        if (!File.Exists("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Tasks\\" + "pushUpstask.json"))
        {
            string json = JsonConvert.SerializeObject(pushUpstask);
            await Task.Run(() => File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Tasks\\pushUpstask.json", json));
        }
        if (!File.Exists("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\tasks\\" + "sitUpstask.json"))
        {
            string json = JsonConvert.SerializeObject(sitUpstask);
            await Task.Run(() => File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Tasks\\sitUpstask.json", json));
        }
        if (!File.Exists("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\tasks\\" + "jumpingJackstask.json"))
        {
            string json = JsonConvert.SerializeObject(jumpingJackstask);
            await Task.Run(() => File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Tasks\\jumpingJackstask.json", json));
        }
        
    }
}
public class PushUps
{
    public string TaskType = "PushUps";
    public int Count = 10;
    public int XP = 2;
    public bool IsInProgress = false;
}
public class SitUps
{
    public string TaskType = "SitUps";
    public int Count = 15;
    public int XP = 2;
    public bool IsInProgress = false;
}
public class JumpingJacks
{
    public string TaskType = "JumpingJacks";
    public int Count = 15; 
    public int XP = 2;
    public bool IsInProgress = false;
}


