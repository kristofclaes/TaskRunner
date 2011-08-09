using System.Collections.Generic;

namespace TaskRunner
{
    internal interface ITaskLoader
    {
        List<TaskInformation> FindTasks();
    }
}