using System;
using System.Linq;

namespace TaskRunner
{
    internal class TaskInformation
    {
        public Type TaskType { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }

        public TaskInformation(Type taskType, string description)
        {
            TaskType = taskType;
            Description = description;
            Name = taskType.Name;
        }

        public override string ToString()
        {
            if(!String.IsNullOrWhiteSpace(Description))
            {
                return String.Format("{0} ({1})", Name, Description);
            }
            
            return Name;
        }
    }
}
