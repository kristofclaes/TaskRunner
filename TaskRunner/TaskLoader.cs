﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TaskRunner
{
    internal class TaskLoader
    {
         public List<TaskInformation> FindTasks()
         {
             return (from t in Assembly.GetEntryAssembly().GetTypes()
                     where typeof(ITask).IsAssignableFrom(t)
                     select new TaskInformation(t)).ToList();
         }
    }
}