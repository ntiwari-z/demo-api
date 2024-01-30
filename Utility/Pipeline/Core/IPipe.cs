namespace Utility.Pipeline.Core
{
    public interface IPipe
    {
        Task<object> ExecuteAsync(object input);
    }
}

