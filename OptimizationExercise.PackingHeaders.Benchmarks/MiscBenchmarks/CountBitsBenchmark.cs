using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.InteropServices;

namespace OptimizationExercise.PackingHeaders.Benchmarks.MiscBenchmarks
{
    public class CountBitsBenchmark : MicroBenchmarkBase
    {
        // crank number up until benchmarkdotnet stops complaining
        private const int NumElements = 120_000_000;

        public ulong[] Data { get; set; } = Array.Empty<ulong>();

        private readonly byte[] StoreInto = new byte[NumElements];

        [GlobalSetup]
        public override void GlobalSetup()
        {
            var rand = new Random(2022_06_04);
            Data = new ulong[NumElements];

            Span<byte> data = stackalloc byte[sizeof(ulong)];
            Span<ulong> punned = MemoryMarshal.Cast<byte, ulong>(data);

            for (var i = 0; i < Data.Length; i++)
            {
                data.Clear();

                rand.NextBytes(data);

                Data[i] = punned[0];
            }
        }

        [IterationSetup]
        public override void IterationSetup()
        {
            Array.Clear(StoreInto);
        }

        [Benchmark(Baseline = true)]
        public override void Naive()
        {
            for(var i = 0; i < Data.Length; i++)
            {
                StoreInto[i] = Common.Helpers.CountSetBits_Naive(Data[i]);
            }
        }

        [Benchmark]
        public override void Optimized()
        {
            for (var i = 0; i < Data.Length; i++)
            {
                StoreInto[i] = Common.Helpers.CountSetBits_Intrinsics(Data[i]);
            }
        }
    }
}
