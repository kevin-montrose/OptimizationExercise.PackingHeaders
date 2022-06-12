using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OptimizationExercise.PackingHeaders.PackedImpl
{
    /// <summary>
    /// 10 strings laid out sequentially.
    /// 
    /// Only valid on 64-bit systems.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = sizeof(ulong) * 10)]
    internal struct PackedData
    {
        [FieldOffset(0 * 8)]
        internal string? data0;
        [FieldOffset(1 * 8)]
        internal string? data1;
        [FieldOffset(2 * 8)]
        internal string? data2;
        [FieldOffset(3 * 8)]
        internal string? data3;
        [FieldOffset(4 * 8)]
        internal string? data4;
        [FieldOffset(5 * 8)]
        internal string? data5;
        [FieldOffset(6 * 8)]
        internal string? data6;
        [FieldOffset(7 * 8)]
        internal string? data7;
        [FieldOffset(8 * 8)]
        internal string? data8;
        [FieldOffset(9 * 8)]
        internal string? data9;
    }
}
