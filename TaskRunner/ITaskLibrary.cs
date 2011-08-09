using System.Collections.ObjectModel;

namespace TaskRunner
{
    internal interface ITaskLibrary
    {
        void RunTask(string name);
        ReadOnlyCollection<TaskInformation> Tasks();
    }
}