namespace Utility.Pipeline.Core
{
    public class Pipeline<T1, T2> : IPipeline<T1, T2> where T2 : class where T1 : class
    {
        private readonly List<IPipe> _pipes;


        public Pipeline()
        {
            _pipes = new List<IPipe>();
        }
        public Pipeline(List<IPipe> pipes)
        {
            _pipes = pipes;
        }

        public async Task<T2> ExecuteAsync(T1 input)
        {
            object startInput = input;
            foreach (var pipe in _pipes)
            {
                startInput = await pipe.ExecuteAsync(startInput);
            }
            return startInput as T2;
        }

        public Pipeline<T3, T2> AddPipe<T3>(Pipe<T1, T3> pipe) where T3 : class
        {
            _pipes.Add(pipe);
            return new Pipeline<T3, T2>(_pipes);
        }
    }
}

