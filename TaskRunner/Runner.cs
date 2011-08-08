using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TaskRunner
{
    public class Runner
    {
        private readonly Dictionary<string, TaskInformation> tasks;

        public Runner()
        {
            tasks = (from t in Assembly.GetCallingAssembly().GetTypes()
                                 where typeof (ITask).IsAssignableFrom(t)
                                 select t).ToDictionary(x => x.Name.ToLower(), x => new TaskInformation(x));
        }

        public void Go()
        {
            SayHello();
        }

        public void RunTask(string name)
        {
            if(tasks.ContainsKey(name.ToLower()))
            {
                using (var instance = Activator.CreateInstance(tasks[name].TaskType) as ITask)
                {
                    if(instance != null) instance.Run();
                }
            }
        }

        private void SayHello()
        {
            Console.WriteLine("Welcome to the TaskRunner. Type 'list' to see a list of available tasks to run. Type the name of task to run it or type 'exit' to close the TaskRunner.");

            Console.Write(" > ");
            var command = Console.ReadLine();
            TakeAction(command);
        }

        private void TakeAction(string command)
        {
            if(command.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(1);
                return;
            }
            
            if (command.Equals("list", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine();
                Console.WriteLine("The following commands are available: ");
                foreach(var ti in tasks)
                {
                    if (ti.Value.HasDescription)
                    {
                        Console.WriteLine(" - {0} ({1})", ti.Value.Name, ti.Value.Description);
                    }
                    else
                    {
                        Console.WriteLine(" - {0}", ti.Value.Name);
                    }
                }
            }
            else
            {
                try
                {
                    RunTask(command);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unfortunately an error occured while trying to execute the '{0}' task: ", command);
                    Console.WriteLine(e.ToString());
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Task '{0}' executed. What's next?", command);
            Console.Write(" > ");
            var newCommand = Console.ReadLine();
            TakeAction(newCommand);
        }
    }
}
