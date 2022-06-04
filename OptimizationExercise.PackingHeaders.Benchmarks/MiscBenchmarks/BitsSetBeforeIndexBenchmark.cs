using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.InteropServices;

namespace OptimizationExercise.PackingHeaders.Benchmarks.MiscBenchmarks
{
    public class BitsSetBeforeIndexBenchmark : MicroBenchmarkBase
    {
        // crank number up until benchmarkdotnet stops complaining
        private const int NumElements = 2_200_000;

        public ulong[] Data { get; set; } = Array.Empty<ulong>();

        private readonly byte[] StoreInto = new byte[NumElements * 64];

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
            var storeIx = 0;
            for (var i = 0; i < Data.Length; i++)
            {
                for(var bit = 0; bit < 64; bit++)
                {
                    StoreInto[storeIx] = Common.Helpers.BitsSetBeforeIndex_Naive(Data[i], (byte)bit);
                    storeIx++;
                }
            }
        }

        [Benchmark]
        public override void Optimized()
        {
            var storeIx = 0;
            for (var i = 0; i < Data.Length; i++)
            {
                for (var bit = 0; bit < 64; bit++)
                {
                    StoreInto[storeIx] = Common.Helpers.BitsSetBeforeIndex_Intrinsics(Data[i], (byte)bit);
                    storeIx++;
                }
            }
        }
    }
}
