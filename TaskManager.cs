using System.Formats.Asn1;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace taskManager
{
    
    public enum TaskTypes{
        personal,
        work,
        errands
    }
    

    public class Task
    {
        
        public string Name;
        public string Description;
        public TaskTypes Type{ get; set; }
        public bool isCompleted;
    }

    public class TaskManager
    {
        public List <Task> Tasks = new List<Task>();
        public string FilePath = "data.csv";

        public void AddTask(string name, string description, string type, bool isCompleted)
        {
            try
            {
                TaskTypes neww = (TaskTypes)Enum.Parse(typeof(TaskTypes), type);
                Task t = new Task { Name = name, Description = description, Type = neww, isCompleted = isCompleted };
                Tasks.Add(t);

                WriteToFile(t);
            }
            catch (Exception E)
            {
                Console.WriteLine($"Error occured: {E.ToString}");
            }
     
        }

        public void DisplayTasks(List<Task>? tasks = null)
        {

            if(Tasks == null){
                Console.WriteLine("no current tasks");
            }
            Console.WriteLine("Tasks:");
            
            foreach (Task task in Tasks)
            {
                Console.WriteLine($"{task.Name},{task.Description},{task.Type},{task.isCompleted}");
            }
        }

        public async void WriteToFile(Task task)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    string value;
                    if (task.isCompleted)
                        value = "Completed";
                    else
                    {
                        value = "Not Completed";
                    }


                    await writer.WriteAsync($"{task.Name} {task.Description} {task.Type} {task.isCompleted}\n");

                    Console.WriteLine("successfully appended to " + FilePath);
                }
            }
            catch (Exception E)
            {
                Console.WriteLine("error appending: " + E.Message);
            }
        }

        public async void ReadFromFile()
        {
            try
            {
                using StreamReader reader = new(FilePath);
                String line;

                while ((line = await reader.ReadLineAsync()) != null && line.Length > 1)
                {
                    List<String> split = line.Split(" ").ToList();
                    Console.Write(split[2]);
                    AddTask(split[0],split[1],split[2],split[3] == "True");
                }
            }
            catch (Exception E)
            {
                Console.WriteLine($"Error reading the file: {E.Message}");
            }
        }



        public void updateTask(string Name, string Description, TaskTypes Type)
        {
            foreach (Task t in Tasks)
            {
                if (t.Name == t.Name)
                {
                    t.Type = Type;
                    t.Description = Description;
                    Task neww = new Task { Name = Name, Description = Description, Type = Type, isCompleted = t.isCompleted };
                    WriteToFile(neww);
                }
            }

        }

        List<Task> filterTasksType(TaskTypes name)
        {
            return Tasks.Where(task => task.Type == name).ToList();
        }


        public List<Task> filterTasksCompleted(bool isCompleted)
        {
            return Tasks.Where(task => task.isCompleted == isCompleted).ToList();
          
        }



    }

    public class Program
    {
        public static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            taskManager.AddTask("abb", "not described", "personal", false);
            taskManager.AddTask("bbb", "b", "work", true);
            

            //taskManager.ReadFromFile();
            taskManager.DisplayTasks();
            taskManager.updateTask("abb", "very described", (TaskTypes)int.Parse("2"));
            taskManager.DisplayTasks();

            List<Task> filtered = taskManager.filterTasksCompleted(true);
            foreach (Task t in filtered)
            {
                Console.WriteLine($"{t.Name} { t.Description}");  
            }

        }
    }
}
