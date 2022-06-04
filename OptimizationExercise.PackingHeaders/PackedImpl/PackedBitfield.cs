using System.Runtime.InteropServices;

namespace OptimizationExercise.PackingHeaders.PackedImpl
{
    /// <summary>
    /// 192 bit bitfield
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = sizeof(ulong) *3 )]
    internal struct PackedBitfield
    {
        [FieldOffset(0 * sizeof(ulong))]
        internal ulong bitfield0;
        [FieldOffset(1 * sizeof(ulong))]
        internal ulong bitfield1;
        [FieldOffset(2 * sizeof(ulong))]
        internal ulong bitfield2;
    }
}
