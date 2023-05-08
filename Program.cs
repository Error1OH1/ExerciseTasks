

using ExerciseTasks;

namespace runExerciseTask;

class Program
{
    static void Main(string[] args)
    {
        var generateTask = Tasks.GenerateTasksEnvironment();
        generateTask.Wait();
        //string username = UserAccessMenu.Prompt();
        string username = "test";
        TaskMain.DisplayTask(username);
    }
}