using System;

namespace TaskRunner
{
    public interface ITask : IDisposable
    {
        void Run();
    }
}