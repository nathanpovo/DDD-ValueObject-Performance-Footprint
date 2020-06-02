using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using System.Collections.Generic;

namespace DDD.ValueObject.PerformanceTests
{
    /// <summary>
    /// This class is responsible to extend the default configuration of "BenchmarkDotNet"
    /// </summary>
    public class Config : ManualConfig
    {
        public Config()
        {
            AddColumnProvider(new BoxPlotColumnProvider());
            AddLogger(new ConsoleLogger());
        }

        /// <summary>
        /// Represent all statistical indicators that are needed to draw blox plot
        /// </summary>
        private sealed class BoxPlotColumnProvider : IColumnProvider
        {
            public IEnumerable<IColumn> GetColumns(Summary summary)
            {
                yield return TargetMethodColumn.Method;
                yield return StatisticColumn.Iterations;
                yield return StatisticColumn.Min;
                yield return StatisticColumn.Q1;
                yield return StatisticColumn.P50;
                yield return StatisticColumn.Mean;
                yield return StatisticColumn.Q3;
                yield return StatisticColumn.P95;
                yield return StatisticColumn.Max;
            }
        }
    }
}
