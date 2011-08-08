namespace TaskRunner.Sample
{
    public class ThrowError : ITask
    {
        public void Dispose()
        {
            
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}