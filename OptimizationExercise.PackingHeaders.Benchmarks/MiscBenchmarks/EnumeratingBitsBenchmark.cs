using BenchmarkDotNet.Attributes;
using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OptimizationExercise.PackingHeaders.Benchmarks.MiscBenchmarks
{
    /// <summary>
    /// Benchmarking covering different ways of enumerating the set bits in a PackedBitfield
    /// </summary>
    public class EnumeratingBitsBenchmark : MicroBenchmarkBase
    {
        private const int Iterations = 100_000;

        private PackedBitfield[] Bitfields = new PackedBitfield[1024];

        [ParamsSource(nameof(GetNumBitsSet))]
        public int NumBitsSet { get; set; }

        [GlobalSetup]
        public override void GlobalSetup()
        {
            Span<byte> data = stackalloc byte[sizeof(ulong)];
            Span<ulong> punned = MemoryMarshal.Cast<byte, ulong>(data);

            var allPossible = Enumerable.Range(0, 3).SelectMany(bitfield => Enumerable.Range(0, 64).Select(bit => (Bitfield: bitfield, Bit: bit))).ToArray();

            var rand = new Random(2022_06_06);
            for (var i = 0; i < Bitfields.Length; i++)
            {
                var remaining = allPossible.ToList();
                for (var j = 0; j < NumBitsSet; j++)
                {
                    var ix = rand.Next(remaining.Count);
                    var toUse = remaining[ix];
                    remaining.RemoveAt(ix);

                    ref ulong toUpdate = ref Unsafe.Add(ref Bitfields[i].bitfield0, toUse.Bitfield);
                    toUpdate |= (1UL << toUse.Bit);
                }
            }
        }

        [Benchmark(Baseline = true)]
        public override void Naive()
        {
            Span<byte> storeInto = stackalloc byte[NumBitsSet];

            for (var i = 0; i < Bitfields.Length; i++)
            {
                storeInto.Fill(255);
                var storeIx = 0;

                ref ulong dataStart = ref Bitfields[i].bitfield0;
                for (var bitfieldOffset = 0; bitfieldOffset < 3; bitfieldOffset++)
                {
                    var bitfield = Unsafe.Add(ref dataStart, bitfieldOffset);

                    byte curIx = 0;
                    while (true)
                    {
                        var bitIx = Common.Helpers.NextSetBit_Naive(bitfield, curIx);
                        if (bitIx == 64)
                        {
                            break;
                        }

                        storeInto[storeIx] = (byte)(bitfieldOffset * 64 + bitIx);
                        storeIx++;
                        curIx = (byte)(bitIx + 1);
                    }
                }
            }
        }

        [Benchmark]
        public override void Optimized()
        {
            Span<byte> storeInto = stackalloc byte[NumBitsSet];

            for (var i = 0; i < Bitfields.Length; i++)
            {
                storeInto.Fill(255);
                var storeIx = 0;

                ref ulong dataStart = ref Bitfields[i].bitfield0;
                for (var bitfieldOffset = 0; bitfieldOffset < 3; bitfieldOffset++)
                {
                    var bitfield = Unsafe.Add(ref dataStart, bitfieldOffset);

                    var mask = 1UL;
                    while (true)
                    {
                        var bitIx = Common.Helpers.NthSetBit_Intrinsics(bitfield, mask);
                        if (bitIx == 64)
                        {
                            break;
                        }

                        storeInto[storeIx] = (byte)(bitfieldOffset * 64 + bitIx);
                        storeIx++;
                        mask <<= 1;
                    }
                }
            }
        }

        public IEnumerable<int> GetNumBitsSet()
        => Enumerable.Range(0, Constants.MaximumSetHeaders + 1);
    }
}
