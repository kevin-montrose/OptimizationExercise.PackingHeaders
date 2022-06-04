using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;

namespace OptimizationExercise.PackingHeaders.Tests
{
    public class MiscTests
    {
        [Fact]
        public void CheckConstants()
        {
            Assert.True(Constants.MaximumSetHeaders <= Constants.HeaderNamesCount);
            Assert.Equal(Enum.GetNames<HeaderNames>().Length, Constants.HeaderNamesCount);

            Assert.Equal(Constants.MaximumSetHeaders, typeof(PackedData).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Length);
            Assert.Equal(Constants.HeaderNamesCount, typeof(PackedBitfield).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Length * (sizeof(ulong) * 8));
        }

        private static void TrailingZeroByteCount_Common_ULong(Func<ulong, byte> del)
        {
            Assert.Equal(8, del(0UL));

            for (var i = 0; i < 64; i++)
            {
                var asMask = (1UL << i);
                var res = del(asMask);
                Assert.Equal(i / 8, res);
            }

            Span<byte> bytes = stackalloc byte[8];
            Span<ulong> asULong = MemoryMarshal.Cast<byte, ulong>(bytes);

            var rand = new Random(2022_06_03);
            for (var i = 0; i < 1_000_000; i++)
            {
                rand.NextBytes(bytes);
                var val = asULong[0];

                var expected = BitOperations.TrailingZeroCount(val) / 8;
                var actual = del(val);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void TrailingZeroByteCount_Naive_ULong()
        => TrailingZeroByteCount_Common_ULong(static (ulong x) => Helpers.TrailingZeroByteCount_Naive(x));

        [Fact]
        public void TrailingZeroByteCount_Intrinscs_ULong()
        => TrailingZeroByteCount_Common_ULong(static (ulong x) => Helpers.TrailingZeroByteCount_Intrinsics(x));

        private static void TrailingZeroByteCount_Common_UInt(Func<uint, byte> del)
        {
            Assert.Equal(4, del(0U));

            for (var i = 0; i < 32; i++)
            {
                var asMask = (1U << i);
                var res = del(asMask);
                Assert.Equal(i / 8, res);
            }

            Span<byte> bytes = stackalloc byte[4];
            Span<uint> asUInt = MemoryMarshal.Cast<byte, uint>(bytes);

            var rand = new Random(2022_06_03);
            for (var i = 0; i < 1_000_000; i++)
            {
                rand.NextBytes(bytes);
                var val = asUInt[0];

                var expected = BitOperations.TrailingZeroCount(val) / 8;
                var actual = del(val);

                Assert.Equal(expected, actual);
            }

        }

        [Fact]
        public void TrailingZeroByteCount_Naive_UInt()
        => TrailingZeroByteCount_Common_UInt(static (uint x) => Helpers.TrailingZeroByteCount_Naive(x));

        [Fact]
        public void TrailingZeroByteCount_Intrinsics_UInt()
        => TrailingZeroByteCount_Common_UInt(static (uint x) => Helpers.TrailingZeroByteCount_Intrinsics(x));

        private static void TrailingZeroByteCount_Common_UShort(Func<ushort, byte> del)
        {
            Assert.Equal(2, del((ushort)0));

            for (var i = 0; i < 16; i++)
            {
                var asMask = (ushort)(1 << i);
                var res = del(asMask);
                Assert.Equal(i / 8, res);
            }

            Span<byte> bytes = stackalloc byte[2];
            Span<ushort> asUShort = MemoryMarshal.Cast<byte, ushort>(bytes);

            var rand = new Random(2022_06_03);
            for (var i = 0; i < 1_000_000; i++)
            {
                rand.NextBytes(bytes);
                var val = asUShort[0];

                var expected = BitOperations.TrailingZeroCount(val) / 8;
                if (expected == 4)
                {
                    // there's no ushort overload, so we're actually using the uint version... which returns 4 when all 0
                    expected = 2;
                }

                var actual = del(val);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void TrailingZeroByteCount_Naive_UShort()
        => TrailingZeroByteCount_Common_UShort(static (ushort x) => Helpers.TrailingZeroByteCount_Naive(x));

        [Fact]
        public void TrailingZeroByteCount_Intrinsics_UShort()
        => TrailingZeroByteCount_Common_UShort(static (ushort x) => Helpers.TrailingZeroByteCount_Intrinsics(x));

        private static void CountSetBits_Common(Func<ulong, byte> del)
        {
            Assert.Equal(0, del(0UL));
            Assert.Equal(64, del(ulong.MaxValue));

            var rand = new Random(2022_06_04);
            var possibleIndexes = Enumerable.Range(0, 64).ToImmutableList();
            for (var toSet = 0; toSet <= 64; toSet++)
            {
                for (var iter = 0; iter < 10_000; iter++)
                {
                    var remaining = possibleIndexes.ToList();
                    var val = 0UL;
                    for (var i = 0; i < toSet; i++)
                    {
                        var ix = rand.Next(remaining.Count);
                        var bit = remaining[ix];
                        remaining.RemoveAt(ix);

                        val |= (1UL << bit);
                    }

                    var res = del(val);
                    Assert.Equal(toSet, res);
                }
            }
        }

        [Fact]
        public void CountSetBits_Naive()
        => CountSetBits_Common(static (ulong x) => Helpers.CountSetBits_Naive(x));

        [Fact]
        public void CountSetBits_Intrinsics()
        => CountSetBits_Common(static (ulong x) => Helpers.CountSetBits_Intrinsics(x));

        private static void BitsSetBeforeIndex_Common(Func<ulong, byte, byte> del)
        {
            for (var i = 0; i < 64; i++)
            {
                Assert.Equal(0, del(0UL, (byte)i));
                Assert.Equal(i, del(ulong.MaxValue, (byte)i));
            }

            var rand = new Random(2022_06_04);

            Span<byte> data = stackalloc byte[sizeof(ulong)];
            Span<ulong> punned = MemoryMarshal.Cast<byte, ulong>(data);

            for (var i = 0; i < 100_000; i++)
            {
                rand.NextBytes(data);
                var l = punned[0];

                for (var j = 0; j < 64; j++)
                {
                    var masked = l & ((1UL << j) - 1);
                    var expect = BitOperations.PopCount(masked);
                    var actual = del(l, (byte)j);
                    Assert.Equal(expect, actual);
                }
            }
        }

        [Fact]
        public void BitsSetBeforeIndex_Naive()
        => BitsSetBeforeIndex_Common(static (ulong x, byte y) => Helpers.BitsSetBeforeIndex_Naive(x, y));

        [Fact]
        public void BitsSetBeforeIndex_Intrinsics()
        => BitsSetBeforeIndex_Common(static (ulong x, byte y) => Helpers.BitsSetBeforeIndex_Intrinsics(x, y));

        [Fact]
        public void NextSetBit_Naive()
        {
            for (var i = 0; i < 64; i++)
            {
                Assert.Equal(64, Helpers.NextSetBit_Naive(0UL, (byte)i));
                Assert.Equal(i, Helpers.NextSetBit_Naive(ulong.MaxValue, (byte)i));
            }

            var rand = new Random(2022_06_05);
            var availableBits = Enumerable.Range(0, 64).ToArray();

            for (var i = 0; i < 100_000; i++)
            {
                var numBitsSet = rand.Next(65);
                var remainingBits = availableBits.ToList();

                var toSet = new List<int>();

                for (var j = 0; j < numBitsSet; j++)
                {
                    var ix = rand.Next(remainingBits.Count);
                    toSet.Add(remainingBits[ix]);
                    remainingBits.RemoveAt(ix);
                }

                var expected = 0UL;
                foreach (var bitIx in toSet)
                {
                    expected |= (1UL << bitIx);
                }

                toSet.Sort();

                var read = 0UL;
                byte startIx = 0;
                while (true)
                {
                    var bitIx = Helpers.NextSetBit_Naive(expected, startIx);
                    if (bitIx == 64)
                    {
                        break;
                    }
                    read |= (1UL << bitIx);
                    startIx = (byte)(bitIx + 1);
                }

                Assert.Equal(expected, read);
            }
        }

        [Fact]
        public void NthSetBit_Intrinsics()
        {
            for (var i = 0; i < 64; i++)
            {
                Assert.Equal(64, Helpers.NextSetBit_Naive(0UL, (byte)i));
                Assert.Equal(i, Helpers.NextSetBit_Naive(ulong.MaxValue, (byte)i));
            }

            var rand = new Random(2022_06_05);
            var availableBits = Enumerable.Range(0, 64).ToArray();

            for (var i = 0; i < 100_000; i++)
            {
                var numBitsSet = rand.Next(65);
                var remainingBits = availableBits.ToList();

                var toSet = new List<int>();

                for (var j = 0; j < numBitsSet; j++)
                {
                    var ix = rand.Next(remainingBits.Count);
                    toSet.Add(remainingBits[ix]);
                    remainingBits.RemoveAt(ix);
                }

                var expected = 0UL;
                foreach (var bitIx in toSet)
                {
                    expected |= (1UL << bitIx);
                }

                toSet.Sort();

                var read = 0UL;
                for (var n = 0; n < 64; n++)
                {
                    ulong mask = (1UL << n);
                    var bitIx = Helpers.NthSetBit_Intrinsics(expected, mask);
                    if (bitIx == 64)
                    {
                        break;
                    }

                    read |= (1UL << bitIx);
                }

                Assert.Equal(expected, read);
            }
        }

        private static void ZeroHighBits_Common(Func<ulong, byte, ulong> del)
        {
            for (var i = 0; i < 64; i++)
            {
                Assert.Equal(0UL, del(0UL, (byte)i));
                Assert.Equal(ulong.MaxValue & ((1UL << i) - 1), del(ulong.MaxValue, (byte)i));
            }

            var rand = new Random(2022_06_07);

            Span<byte> data = stackalloc byte[sizeof(ulong)];
            Span<ulong> punned = MemoryMarshal.Cast<byte, ulong>(data);

            for (var i = 0; i < 100_000; i++)
            {
                var ix = (byte)rand.Next(64);
                rand.NextBytes(data);
                var val = punned[0];

                var expected = val & ((1UL << ix) - 1);
                var actual = del(val, ix);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void ZeroHighBits_Naive()
        => ZeroHighBits_Common(static (ulong x, byte y) => Helpers.ZeroHighBits_Naive(x, y));


        [Fact]
        public void ZeroHighBits_Intrinsics()
        => ZeroHighBits_Common(static (ulong x, byte y) => Helpers.ZeroHighBits_Intrinsics(x, y));

        private static void BitFieldExtract_Common(Func<ulong, byte, byte, ulong> del)
        {
            for (var ix = 0; ix < 64; ix++)
            {
                for (var len = 0; len <= (64 - ix); len++)
                {
                    Assert.Equal(0UL, del(0UL, (byte)ix, (byte)len));

                    ulong expected;
                    if (len == 64)
                    {
                        expected = ulong.MaxValue;
                    }
                    else
                    {
                        expected = (1UL << len) - 1;
                    }

                    Assert.Equal(expected, del(ulong.MaxValue, (byte)ix, (byte)len));
                }
            }


            Span<byte> data = stackalloc byte[sizeof(ulong)];
            Span<ulong> punned = MemoryMarshal.Cast<byte, ulong>(data);

            var rand = new Random(2022_06_07);
            for (var i = 0; i < 10_000; i++)
            {
                rand.NextBytes(data);
                var val = punned[0];

                for (var ix = 0; ix < 64; ix++)
                {
                    for (var len = 0; len <= (64 - ix); len++)
                    {
                        var actual = del(val, (byte)ix, (byte)len);

                        var expected = val >> ix;

                        if (len != 64)
                        {
                            expected &= ((1UL << len) - 1);
                        }

                        Assert.Equal(expected, actual);
                    }
                }
            }
        }

        [Fact]
        public void BitFieldExtract_Naive()
        => BitFieldExtract_Common(static (ulong x, byte y, byte z) => Helpers.BitFieldExtract_Naive(x, y, z));


        [Fact]
        public void BitFieldExtract_Intrinsics()
        => BitFieldExtract_Common(static (ulong x, byte y, byte z) => Helpers.BitFieldExtract_Intrinsics(x, y, z));
    }
}
