namespace Utility.Pipeline.Core
{
    public abstract class Pipe<T1, T2> : IPipe where T1 : class where T2 : class
    {
        public abstract Task<T2> ExecuteAsync(T1 input);

        public async Task<object> ExecuteAsync(object input)
        {
            return await ExecuteAsync(input as T1);
        }
    }
}

