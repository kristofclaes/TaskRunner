using System;

namespace TaskRunner.Sample
{
    [TaskDescription("SomeTaskKey","I'm the description for this task.")]
    public class SomeTask : ITask
    {
        public void Run()
        {
            Console.WriteLine("Hi, I'm SomeTest.");
        }

        public void Dispose()
        {
            
        }
    }
}
