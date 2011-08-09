using System;
using System.Linq;

namespace TaskRunner
{
    internal class TaskInformation
    {
        public Type TaskType { get; private set; }
        public string Description { get; private set; }

        public bool HasDescription
        {
            get { return !String.IsNullOrWhiteSpace(Description); }
        }

        public string Name
        {
            get { return TaskType.Name; }
        }

        public TaskInformation(Type taskType)
        {
            TaskType = taskType;

            GetDescription();
        }

        private void GetDescription()
        {
            var attributes = TaskType.GetCustomAttributes(true).Where(a => a is TaskDescriptionAttribute).FirstOrDefault() as TaskDescriptionAttribute;
            Description = attributes == null ? String.Empty : attributes.Description;
        }

        public override string ToString()
        {
            if(HasDescription)
            {
                return String.Format("{0} ({1})", Name, Description);
            }
            
            return Name;
        }
    }
}
