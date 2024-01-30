namespace Utility.Pipeline.Core
{
    public interface IPipeline<Input, Output>
    {
        Task<Output> ExecuteAsync(Input input);
    }
}

