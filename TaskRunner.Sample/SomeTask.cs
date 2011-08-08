using System;

namespace TaskRunner.Sample
{
    [TaskDescription("I'm the description for this task.")]
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
