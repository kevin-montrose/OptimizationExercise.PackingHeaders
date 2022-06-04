using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.InteropServices;

namespace OptimizationExercise.PackingHeaders.Benchmarks.MiscBenchmarks
{
    public class BitTestBenchmark : MicroBenchmarkBase
    {
        private ulong[] Data = Array.Empty<ulong>();

        [GlobalSetup]
        public override void GlobalSetup()
        {
            var rand = new Random(2022_06_07);

            Data = new ulong[1_000_000];

            Span<byte> data = stackalloc byte[sizeof(ulong)];
            Span<ulong> punned = MemoryMarshal.Cast<byte, ulong>(data);
            
            for(var i = 0; i < Data.Length; i++)
            {
                rand.NextBytes(data);
                Data[i] = punned[0];
            }
        }

        [Benchmark(Baseline = true)]
        public override void Naive()
        {
            Span<bool> storeInto = stackalloc bool[64];
            for(var i = 0; i < Data.Length; i++)
            {
                var val = Data[i];

                for(byte ix = 0; ix < 64; ix++)
                {
                    var mask = (1UL << ix);

                    var set = (val & mask) != 0;
                    storeInto[ix] = set;
                }
            }
        }

        [Benchmark]
        public override void Optimized()
        {
            Span<bool> storeInto = stackalloc bool[64];
            for (var i = 0; i < Data.Length; i++)
            {
                var val = Data[i];

                for (byte ix = 0; ix < 64; ix++)
                {
                    var set = (val & (1UL << ix)) != 0;
                    storeInto[ix] = set;
                }
            }
        }
    }
}
