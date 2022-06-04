using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.InteropServices;

namespace OptimizationExercise.PackingHeaders.Benchmarks.MiscBenchmarks
{
    /// <summary>
    /// Benchmarks "naive" implementations of TrailingZeroCount versus the intrinsic.
    /// 
    /// Tries all single bits versions for the various operands, AND a bunch of randomly
    /// generated data.
    /// </summary>
    public class TrailingZeroCountBenchmark : MicroBenchmarkBase
    {
        // crank number up until benchmarkdotnet stops complaining
        private const int NumElements = 80_000_000;

        [Params(sizeof(ushort), sizeof(uint), sizeof(ulong))]
        public int OperandSizeBytes { get; set; }

        public ulong[] ULongs { get; set; } = Array.Empty<ulong>();
        public uint[] UInts { get; set; } = Array.Empty<uint>();
        public ushort[] UShorts { get; set; } = Array.Empty<ushort>();

        private readonly byte[] StoreInto = new byte[NumElements];

        [GlobalSetup]
        public override void GlobalSetup()
        {
            ULongs = GenerateData<ulong>();
            UInts = GenerateData<uint>();
            UShorts = GenerateData<ushort>();

            static T[] GenerateData<T>()
                where T : unmanaged
            {
                var sizeBytes = Marshal.SizeOf<T>();

                var rand = new Random(2022_06_04);
                var ret = new T[NumElements];

                Span<byte> data = stackalloc byte[sizeBytes];
                Span<T> punned = MemoryMarshal.Cast<byte, T>(data);

                var bits = sizeBytes * 8;
                for (var i = 0; i < bits; i++)
                {
                    var byteIndex = i / 8;
                    var bitIndex = i % 8;

                    var byteMask = (byte)(1 << bitIndex);

                    data.Clear();
                    data[byteIndex] |= byteMask;

                    ret[i] = punned[0];
                }

                for (var i = bits; i < ret.Length; i++)
                {
                    data.Clear();

                    var nonZeroByteIx = rand.Next(sizeBytes + 1);

                    if (nonZeroByteIx < sizeBytes)
                    {
                        while (data[nonZeroByteIx] == 0)
                        {
                            data[nonZeroByteIx] = (byte)rand.Next();
                        }
                    }

                    ret[i] = punned[0];
                }

                return ret;
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
            switch (OperandSizeBytes)
            {
                case sizeof(ushort):
                    for (var i = 0; i < UShorts.Length; i++)
                    {
                        StoreInto[i] = Common.Helpers.TrailingZeroByteCount_Naive(UShorts[i]);
                    }
                    break;
                case sizeof(uint):
                    for (var i = 0; i < UInts.Length; i++)
                    {
                        StoreInto[i] = Common.Helpers.TrailingZeroByteCount_Naive(UInts[i]);
                    }
                    break;
                case sizeof(ulong):
                    for (var i = 0; i < ULongs.Length; i++)
                    {
                        StoreInto[i] = Common.Helpers.TrailingZeroByteCount_Naive(ULongs[i]);
                    }
                    break;
                default: throw new InvalidOperationException();
            }
        }

        [Benchmark]
        public override void Optimized()
        {
            switch (OperandSizeBytes)
            {
                case sizeof(ushort):
                    for (var i = 0; i < UShorts.Length; i++)
                    {
                        StoreInto[i] = Common.Helpers.TrailingZeroByteCount_Intrinsics(UShorts[i]);
                    }
                    break;
                case sizeof(uint):
                    for (var i = 0; i < UInts.Length; i++)
                    {
                        StoreInto[i] = Common.Helpers.TrailingZeroByteCount_Intrinsics(UInts[i]);
                    }
                    break;
                case sizeof(ulong):
                    for (var i = 0; i < ULongs.Length; i++)
                    {
                        StoreInto[i] = Common.Helpers.TrailingZeroByteCount_Intrinsics(ULongs[i]);
                    }
                    break;
                default: throw new InvalidOperationException();
            }
        }
    }
}
