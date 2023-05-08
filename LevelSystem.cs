using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTasks
{
    public class LevelSystem
    {
        public static void levelSystem(string userName)
        {
            string json = File.ReadAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json");
            dynamic data = JsonConvert.DeserializeObject(json);
            int Level = data.level;
            int Xp = data.XPpercentage;
            if (Xp == 100)
            {
                Level++;
                data.level = Level;
                data.XPpercentage = 0;
                string updatedjson = JsonConvert.SerializeObject(data);
                File.WriteAllText("C:\\Users\\Derpy\\Downloads\\ExerciseTasksUsers\\Users\\" + userName + ".json", updatedjson);
                
            }
        }
    }
}
