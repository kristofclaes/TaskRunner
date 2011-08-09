using System;
using System.Reflection;

namespace TaskRunner
{
    public class Runner
    {
        private readonly ITaskLibrary taskLibrary;
        public Runner()
        {
            taskLibrary = new TaskLibrary();
        }

        public void Go()
        {
            SayHello();
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
                foreach(var ti in taskLibrary.Tasks())
                {
                    Console.WriteLine(" - {0}", ti);
                }
            }
            else
            {
                try
                {
                    taskLibrary.RunTask(command);
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
