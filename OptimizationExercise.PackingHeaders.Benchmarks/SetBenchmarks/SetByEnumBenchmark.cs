using BenchmarkDotNet.Attributes;
using OptimizationExercise.PackingHeaders.ArrayImpl;
using OptimizationExercise.PackingHeaders.Benchmarks.Helpers;
using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.DictionaryImpl;
using OptimizationExercise.PackingHeaders.FieldsImpl;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace OptimizationExercise.PackingHeaders.Benchmarks.SetBenchmarks
{
    /// <summary>
    /// Benchmark for setting values via the <see cref="HeaderNames"/> benchmark.
    /// 
    /// Parameterized by number of headers set and by the order they are set in.
    /// </summary>
    [MemoryDiagnoser]
    public class SetByEnumBenchmark : ImplBenchmarkBase
    {
        public record Parameters(string Order, int NumHeaders)
        {
            public override string ToString()
            => $"{NumHeaders:00}, {Order}";
        }

        // have to pump up iterations until benchmarkdotnet stops complaining
        private const int Iterations = 1_000;

        [ParamsSource(nameof(GetOrderAndCount))]
        public Parameters OrderAndCount { get; set; } = new Parameters("", int.MaxValue);

        private (HeaderNames Header, string Value)[] ToSet = Array.Empty<(HeaderNames Header, string Value)>();

        [GlobalSetup]
        public override void GlobalSetup()
        {
            var chosen = Data.ChooseNumberFrom(Data.AllHeaders, OrderAndCount.NumHeaders).ToImmutableArray();
            var withValues = chosen.Select(t => (Header: t, Value: t + "_value")).ToImmutableArray();

            switch (OrderAndCount.Order)
            {
                case "Ordered": ToSet = withValues.OrderBy(static x => x.Header).ToArray(); break;
                case "Random": ToSet = Data.Shuffle(withValues).ToArray(); break;
                case "Reversed": ToSet = withValues.OrderByDescending(static x => x.Header).ToArray(); break;
                default: throw new InvalidOperationException();
            }
        }

        [Benchmark]
        public override void Dictionary()
        => RunBenchmark<DictionaryHeaders, Dictionary<HeaderNames, string>.KeyCollection.Enumerator>();

        [Benchmark]
        public override void Fields_V1()
        => RunBenchmark<FieldHeaders_V1, FieldHeaders_V1.Enumerator>();

        [Benchmark]
        public override void Fields_V2()
        => RunBenchmark<FieldHeaders_V2, FieldHeaders_V2.Enumerator>();

        [Benchmark]
        public override void Arrays_V1()
        => RunBenchmark<ArrayHeaders_V1, ArrayHeaders_V1.Enumerator>();
        
        [Benchmark]
        public override void Arrays_V2()
        => RunBenchmark<ArrayHeaders_V2, ArrayHeaders_V2.Enumerator>();

        [Benchmark]
        public override void Packed_V1()
        => RunBenchmark<PackedHeaders_V1, PackedHeaders_V1.Enumerator>();

        [Benchmark]
        public override void Packed_V2()
        => RunBenchmark<PackedHeaders_V2, PackedHeaders_V2.Enumerator>();

        [Benchmark]
        public override void Packed_V3()
        => RunBenchmark<PackedHeaders_V3, PackedHeaders_V3.Enumerator>();

        [Benchmark]
        public override void Packed_V4()
        => RunBenchmark<PackedHeaders_V4, PackedHeaders_V4.Enumerator>();

        private void RunBenchmark<T, V>()
            where T : IHeadersStructure<T, V>
            where V : struct, IEnumerator<HeaderNames>
        {
            for (var iter = 0; iter < Iterations; iter++)
            {
                var headers = T.CreateEmpty();
                foreach (var kv in ToSet)
                {
                    headers.Set(kv.Header, kv.Value);
                }
            }
        }

        public static IEnumerable<Parameters> GetOrderAndCount()
        {
            var counts = Enumerable.Range(1, Constants.MaximumSetHeaders).Where(c => (c % 2) == 0);
            var orders = new[] { "Ordered", "Random", "Reversed" };

            foreach (var count in counts)
            {
                foreach (var order in orders)
                {
                    if (count == 0 && order != "Ordered")
                    {
                        continue;
                    }

                    if ((count == 1 || count == 2) && order == "Random")
                    {
                        continue;
                    }

                    yield return new Parameters(order, count);
                }
            }
        }
    }
}
