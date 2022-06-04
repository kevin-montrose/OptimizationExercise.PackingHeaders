using System;
using System.Runtime.CompilerServices;

namespace OptimizationExercise.PackingHeaders.Common
{
    internal static class Helpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte TrailingZeroByteCount_Naive(ulong value)
        {
            var curMask = 0x00_00_00_00_00_00_00_FFUL;
            for (byte i = 0; i < 8; i++)
            {
                if ((value & curMask) != 0)
                {
                    return i;
                }

                curMask <<= 8;
            }

            return 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte TrailingZeroByteCount_Naive(uint value)
        {
            var curMask = 0x00_00_00_FFU;
            for (byte i = 0; i < 4; i++)
            {
                if ((value & curMask) != 0)
                {
                    return i;
                }

                curMask <<= 8;
            }

            return 4;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte TrailingZeroByteCount_Naive(ushort value)
        {
            ushort curMask = 0x00_FF;
            for (byte i = 0; i < 2; i++)
            {
                if ((value & curMask) != 0)
                {
                    return i;
                }

                curMask <<= 8;
            }

            return 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static byte TrailingZeroByteCount_Intrinsics(ulong value)
        {
            if (System.Runtime.Intrinsics.X86.Bmi1.X64.IsSupported)
            {
                return (byte)(System.Runtime.Intrinsics.X86.Bmi1.X64.TrailingZeroCount(value) / 8);
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static byte TrailingZeroByteCount_Intrinsics(uint value)
        {
            if (System.Runtime.Intrinsics.X86.Bmi1.IsSupported)
            {
                return (byte)(System.Runtime.Intrinsics.X86.Bmi1.TrailingZeroCount(value) / 8);
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static byte TrailingZeroByteCount_Intrinsics(ushort value)
        {
            if (System.Runtime.Intrinsics.X86.Bmi1.IsSupported)
            {
                var asUInt = 0xFF_FF_00_00U | value;
                return (byte)(System.Runtime.Intrinsics.X86.Bmi1.TrailingZeroCount(asUInt) / 8);
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte CountSetBits_Naive(ulong v)
        {
            // from: https://graphics.stanford.edu/~seander/bithacks.html#CountBitsSet64
            // v = v - ((v >> 1) & (T)~(T)0/3);                           // temp
            // v = (v & (T)~(T)0/15*3) + ((v >> 2) & (T)~(T)0/15*3);      // temp
            // v = (v + (v >> 4)) & (T)~(T)0/255*15;                      // temp
            // c = (T)(v * ((T)~(T)0/255)) >> (sizeof(T) - 1) * CHAR_BIT; // count

            const ulong Term1 = (~0UL) / 3;
            const ulong Term2 = (~0UL) / 15 * 3;
            const ulong Term3 = (~0UL) / 255 * 15;
            const ulong Term4 = (~0UL) / 255;
            const byte Term5 = (sizeof(ulong) - 1) * 8;

            v = v - ((v >> 1) & Term1);
            v = (v & Term2) + ((v >> 2) & Term2);
            v = (v + (v >> 4)) & Term3;
            var res = (v * Term4) >> Term5;

            return (byte)res;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static byte CountSetBits_Intrinsics(ulong v)
        {
            if (System.Runtime.Intrinsics.X86.Popcnt.X64.IsSupported)
            {
                return (byte)System.Runtime.Intrinsics.X86.Popcnt.X64.PopCount(v);
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte BitsSetBeforeIndex_Naive(ulong bitfield, byte bitIndex)
        {
            var bitIndexAsMask = (1UL << bitIndex);
            var bitsBeforeIndex = bitfield & (bitIndexAsMask - 1);

            return CountSetBits_Naive(bitsBeforeIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static byte BitsSetBeforeIndex_Intrinsics(ulong bitfield, byte bitIndex)
        {
            if (System.Runtime.Intrinsics.X86.Bmi2.X64.IsSupported)
            {
                var withoutHighBits = ZeroHighBits_Intrinsics(bitfield, bitIndex);
                return CountSetBits_Intrinsics(withoutHighBits);
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte NextSetBit_Naive(ulong bitfield, byte fromBitIndex)
        {
            while (fromBitIndex < 64)
            {
                var bitIndexAsMask = (1UL << fromBitIndex);

                var isSet = (bitfield & bitIndexAsMask) != 0;
                if (isSet)
                {
                    return fromBitIndex;
                }

                fromBitIndex++;
            }

            return 64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static byte NthSetBit_Intrinsics(ulong bitfield, ulong mask)
        {
            if (System.Runtime.Intrinsics.X86.Bmi1.X64.IsSupported && System.Runtime.Intrinsics.X86.Bmi2.X64.IsSupported)
            {
                var justNextBit = System.Runtime.Intrinsics.X86.Bmi2.X64.ParallelBitDeposit(mask, bitfield);
                var nextBitIndex = System.Runtime.Intrinsics.X86.Bmi1.X64.TrailingZeroCount(justNextBit);

                return (byte)nextBitIndex;
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong BitFieldExtract_Naive(ulong bitfield, byte startIx, byte length)
        {
            var shifted = bitfield >> startIx;
            ulong mask;
            if(length == 64)
            {
                mask = ulong.MaxValue;
            }
            else
            {
                mask = ((1UL << length) - 1);
            }

            var clipped = shifted & mask;

            return clipped;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static ulong BitFieldExtract_Intrinsics(ulong bitfield, byte startIx, byte length)
        {
            if (System.Runtime.Intrinsics.X86.Bmi1.X64.IsSupported)
            {
                return System.Runtime.Intrinsics.X86.Bmi1.X64.BitFieldExtract(bitfield, startIx, length);

            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong ZeroHighBits_Naive(ulong bitfield, byte bitIndex)
        {
            var toKeepMask = (1UL << bitIndex) - 1;

            return bitfield & toKeepMask;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static ulong ZeroHighBits_Intrinsics(ulong bitfield, byte bitIndex)
        {
            if (System.Runtime.Intrinsics.X86.Bmi1.X64.IsSupported)
            {
                return System.Runtime.Intrinsics.X86.Bmi2.X64.ZeroHighBits(bitfield, (ulong)bitIndex);

            }

            throw new NotImplementedException();
        }
    }
}
