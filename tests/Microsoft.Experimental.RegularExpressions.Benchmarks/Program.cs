using BenchmarkDotNet.Running;

namespace Microsoft.Experimental.RegularExpressions.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args);
        }
    }
}
