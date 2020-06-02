using BenchmarkDotNet.Running;

namespace DDD.ValueObject.PerformanceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Config();
            BenchmarkRunner.Run<ValueObjectTests>(config);
        }
    }
}
