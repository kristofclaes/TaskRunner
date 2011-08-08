using System;

namespace TaskRunner.Sample
{
    public class AnotherTask : ITask
    {
        public void Run()
        {
            Console.WriteLine("Howdy, I'm AnotherTest.");
        }

        public void Dispose()
        {
            
        }
    }
}