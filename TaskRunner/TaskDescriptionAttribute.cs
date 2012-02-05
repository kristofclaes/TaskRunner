using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskRunner
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TaskDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }
        public string Name { get; private set; }

        public TaskDescriptionAttribute(string name, string description)
        {
            Description = description;
            Name = name;
        }
    }
}
