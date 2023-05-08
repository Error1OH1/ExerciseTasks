// LFInteractive LLC. - All Rights Reserved
using Newtonsoft.Json;

namespace ExerciseTasks;

public struct PushUps : ITaskItem
{
    public string TaskType { get; set; } = "PushUps";
    public int Count { get; set; }
    public int XP { get; set; }
    public bool IsInProgress { get; set; }

    public PushUps()
    {
    }
}

public struct SitUps : ITaskItem
{
    public string TaskType { get; set; } = "SitUps";
    public int Count { get; set; }
    public int XP { get; set; }
    public bool IsInProgress { get; set; }

    public SitUps()
    {
    }
}

public struct JumpingJacks : ITaskItem
{
    public string TaskType { get; set; } = "JumpingJacks";
    public int Count { get; set; }
    public int XP { get; set; }
    public bool IsInProgress { get; set; }

    public JumpingJacks()
    {
    }
}

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

public interface ITaskItem
{
    public string TaskType { get; set; }
    public int Count { get; set; }
    public int XP { get; set; }
    public bool IsInProgress { get; set; }
}