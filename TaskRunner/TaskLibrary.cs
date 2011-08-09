using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace TaskRunner
{
    internal class TaskLibrary
    {
        private readonly List<TaskInformation> tasks; 

        public TaskLibrary()
        {
            tasks = (from t in Assembly.GetEntryAssembly().GetTypes()
                     where typeof (ITask).IsAssignableFrom(t)
                     select new TaskInformation(t)).ToList();
        }

        public void RunTask(string name)
        {
            var task = tasks.SingleOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                using (var instance = Activator.CreateInstance(task.TaskType) as ITask)
                {
                    if (instance != null) instance.Run();
                }
            }
        }

        public ReadOnlyCollection<TaskInformation> Tasks()
        {
            return tasks.AsReadOnly();
        }
    }
}