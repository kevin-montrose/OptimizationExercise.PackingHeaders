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
    [MemoryDiagnoser]
    public class CreateWithDictionaryBenchmark : ImplBenchmarkBase
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

        private Dictionary<HeaderNames, string> ToSet = new Dictionary<HeaderNames, string>(0);

        [GlobalSetup]
        public override void GlobalSetup()
        {
            var rand = new Random(2022_06_08);
            ToSet = Create(rand, OrderAndCount.NumHeaders, OrderAndCount.Order);

            static Dictionary<HeaderNames, string> Create(Random rand, int count, string expectedOrder)
            {
                var candidates = Enumerable.Empty<(HeaderNames Header, string Value)>();
                var restartAfter = 50;

                var available = Data.AllHeaders.ToList();
                while (true)
                {
                    var availableForStep = available.ToList();

                    var madeProgress = false;

                    while (availableForStep.Count > 0)
                    {
                        var ix = rand.Next(availableForStep.Count);
                        var header = availableForStep[ix];

                        var updatedCandidates = candidates.Append((Header: header, Value: header + "_value"));
                        var toTest = updatedCandidates.ToDictionary(t => t.Header, t => t.Value);

                        if (IsValid(toTest, expectedOrder))
                        {
                            available.Remove(header);
                            candidates = updatedCandidates;

                            if (toTest.Count == count)
                            {
                                return toTest;
                            }

                            madeProgress = true;
                            break;
                        }
                        else
                        {
                            availableForStep.RemoveAt(ix);
                        }
                    }

                    if (!madeProgress)
                    {
                        restartAfter--;

                        if (restartAfter > 0)
                        {
                            var toPushBack = candidates.Last();
                            candidates = candidates.Take(candidates.Count() - 1).ToList();

                            available.Add(toPushBack.Header);
                        }
                        else
                        {
                            restartAfter = 50;
                            candidates = Enumerable.Empty<(HeaderNames, string)>();
                            available = Data.AllHeaders.ToList();
                        }
                    }
                }
            }

            static bool IsValid(Dictionary<HeaderNames, string> candidate, string expectedOrder)
            => Enumerable.Range(0, 10).All(x => IsValidImpl(candidate, expectedOrder));

            static bool IsValidImpl(Dictionary<HeaderNames, string> candidate, string expectedOrder)
            {
                var keysInOrder = candidate.Keys.OrderBy(static x => x).ToImmutableList();
                var keysInReverseOrder = candidate.Keys.OrderByDescending(static x => x).ToImmutableList();

                var inOrder = true;
                var inReverseOrder = true;

                var ix = 0;
                foreach (var kv in candidate)
                {
                    var expectedInOrder = keysInOrder[ix];
                    inOrder = inOrder && expectedInOrder == kv.Key;

                    var expectedInReverseOrder = keysInReverseOrder[ix];
                    inReverseOrder = inReverseOrder && expectedInReverseOrder == kv.Key;

                    ix++;
                }

                if (inOrder && inReverseOrder)
                {
                    if (candidate.Count > 1)
                    {
                        // shouldn't be possible
                        throw new Exception();
                    }
                }

                if (expectedOrder == "Ordered")
                {
                    return inOrder;
                }

                if (expectedOrder == "Reversed")
                {
                    return inReverseOrder;
                }

                if (expectedOrder == "Random")
                {
                    if(candidate.Count <= 2)
                    {
                        return true;
                    }

                    return !inOrder && !inReverseOrder;
                }

                throw new ArgumentException(nameof(expectedOrder));
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
                var item = T.CreateFromDictionary(ToSet);
                GC.KeepAlive(item);
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
