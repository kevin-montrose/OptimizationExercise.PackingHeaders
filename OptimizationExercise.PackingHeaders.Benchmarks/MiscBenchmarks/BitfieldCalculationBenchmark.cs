using BenchmarkDotNet.Attributes;
using System;
using System.Linq;

namespace OptimizationExercise.PackingHeaders.Benchmarks.MiscBenchmarks
{
    public class BitfieldCalculationBenchmark : MicroBenchmarkBase
    {
        private const int Iterations = 1_000;

        private byte[] Values = Array.Empty<byte>();

        private byte[] StoreBitfield = Array.Empty<byte>();
        private byte[] StoreBit = Array.Empty<byte>();

        [GlobalSetup]
        public override void GlobalSetup()
        {
            var rand = new Random(2022_06_07);

            Values = Enumerable.Range(0, 1_000_000).Select(_ => (byte)rand.Next(byte.MaxValue + 1)).ToArray();
            StoreBitfield = new byte[Values.Length];
            StoreBit = new byte[Values.Length];
        }

        [Benchmark(Baseline = true)]
        public override void Naive()
        {
            var bitfields = StoreBitfield.AsSpan();
            var bits = StoreBit.AsSpan();

            for (var iter = 0; iter < Iterations; iter++)
            {
                bitfields.Clear();
                bits.Clear();

                for (var i = 0; i < Values.Length; i++)
                {
                    var val = Values[i];
                    int bitfield = Math.DivRem(val, 64, out var bit);
                    bitfields[i] = (byte)bitfield;
                    bits[i] = (byte)bit;
                }
            }
        }

        [Benchmark]
        public override void Optimized()
        {
            var bitfields = StoreBitfield.AsSpan();
            var bits = StoreBit.AsSpan();

            for (var iter = 0; iter < Iterations; iter++)
            {
                bitfields.Clear();
                bits.Clear();

                for (var i = 0; i < Values.Length; i++)
                {
                    var val = Values[i];
                    var bitfield = Common.Helpers.BitFieldExtract_Intrinsics(val, 6, 2);
                    var bit = Common.Helpers.ZeroHighBits_Intrinsics(val, 6);
                    bitfields[i] = (byte)bitfield;
                    bits[i] = (byte)bit;
                }
            }
        }
    }
}
