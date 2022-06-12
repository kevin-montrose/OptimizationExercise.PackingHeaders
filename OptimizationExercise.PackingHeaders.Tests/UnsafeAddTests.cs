using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.FieldsImpl;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Xunit;

namespace OptimizationExercise.PackingHeaders.Tests
{
    public class UnsafeAddTests
    {
        [Fact]
        public void PackedDataInBounds()
        {
            var data = new PackedData();
            ref string? start = ref data.data0;
            ref string? calculatedEnd = ref Unsafe.Add(ref start, Constants.MaximumSetHeaders - 1);
            ref string? expectedEnd = ref data.data9;

            // won't read past the end
            Assert.True(Unsafe.AreSame(ref expectedEnd, ref calculatedEnd));

            // configured size covers what's in the struct
            var actualSizeBytes = (int)Unsafe.ByteOffset(ref start, ref expectedEnd) + 8;    // + 8 for the last reference
            var expectedSizeBytes = Marshal.SizeOf<PackedData>();

            Assert.Equal(expectedSizeBytes, actualSizeBytes);
        }

        [Fact]
        public void PackedBitfieldInBounds()
        {
            var data = new PackedBitfield();
            ref ulong start = ref data.bitfield0;
            ref ulong calculatedEnd = ref Unsafe.Add(ref start, 2);
            ref ulong expectedEnd = ref data.bitfield2;

            // won't read past the end
            Assert.True(Unsafe.AreSame(ref expectedEnd, ref calculatedEnd));

            // configured size covers what's in the struct
            var actualSizeBytes = (int)Unsafe.ByteOffset(ref start, ref expectedEnd) + 8;    // + 8 for the last ulong
            var expectedSizeBytes = Marshal.SizeOf<PackedBitfield>();

            Assert.Equal(expectedSizeBytes, actualSizeBytes);
        }

        [Fact]
        public void FieldsDataInBounds()
        {
            var data = new FieldData();
            ref string? start = ref data.aardvark;
            ref string? calculatedEnd = ref Unsafe.Add(ref start, Constants.HeaderNamesCount - 1);
            ref string? expectedEnd = ref data.zebra;

            // won't read past the end
            Assert.True(Unsafe.AreSame(ref expectedEnd, ref calculatedEnd));

            // configured size covers what's in the struct
            var actualSizeBytes = (int)Unsafe.ByteOffset(ref start, ref expectedEnd) + 8;    // + 8 for the last reference
            var expectedSizeBytes = Marshal.SizeOf<FieldData>();

            Assert.Equal(expectedSizeBytes, actualSizeBytes);
        }
    }
}
