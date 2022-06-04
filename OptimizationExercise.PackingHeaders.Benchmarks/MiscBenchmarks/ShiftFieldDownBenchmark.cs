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
    public class ShiftFieldDownBenchmark : MicroBenchmarkBase
    {
        // crank this up until benchmarkdotnet stops complaining
        private const int Iterations = 250_000_000;

        [ParamsSource(nameof(GetShiftDownFromIndexes))]
        public int ShiftDownFromIndex { get; set; }

        private PackedData data;

        public override void GlobalSetup() { }

        [IterationCleanup]
        public override void IterationSetup()
        {
            data.data0 = "a";
            data.data1 = "b";
            data.data2 = "c";
            data.data3 = "d";
            data.data4 = "e";
            data.data5 = "f";
            data.data6 = "g";
            data.data7 = "h";
            data.data8 = "i";
            data.data9 = "j";
        }

        [Benchmark(Baseline = true)]
        public override void Naive()
        {
            var offset = ShiftDownFromIndex;

            for (var i = 0; i < Iterations; i++)
            {
                NaiveImpl(offset);
            }
        }
        [Benchmark]
        public override void Optimized()
        {
            var offset = ShiftDownFromIndex;

            for (var i = 0; i < Iterations; i++)
            {
                OptimizedImpl(offset);
            }
        }

        public static IEnumerable<int> GetShiftDownFromIndexes()
        => Enumerable.Range(0, Constants.MaximumSetHeaders);

        // can't allow the JIT to figure out offset is basically constant
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void NaiveImpl(int offset)
        {
            switch (offset)
            {
                case 0:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    data.data4 = data.data3;
                    data.data3 = data.data2;
                    data.data2 = data.data1;
                    data.data1 = data.data0;
                    break;
                case 1:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    data.data4 = data.data3;
                    data.data3 = data.data2;
                    data.data2 = data.data1;
                    break;
                case 2:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    data.data4 = data.data3;
                    data.data3 = data.data2;
                    break;
                case 3:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    data.data4 = data.data3;
                    break;
                case 4:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    break;
                case 5:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    break;
                case 6:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    break;
                case 7:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    break;
                case 8:
                    data.data9 = data.data8;
                    break;
                case 9:
                    break;
            }
        }

        // can't allow the JIT to figure out offset is basically constant
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OptimizedImpl(int offset)
        {
            var copyLen = (Constants.MaximumSetHeaders - 1) - offset;

            switch (copyLen)
            {
                case 3:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    return;
                case 2:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    return;
                case 1:
                    data.data9 = data.data8;
                    return;
                case 0:
                    return;
            }

            ref string shiftFrom = ref Unsafe.Add(ref data.data0, offset);
            ref string shiftInto = ref Unsafe.Add(ref shiftFrom, 1);
            
            var copyFrom = MemoryMarshal.CreateSpan(ref shiftFrom, copyLen);
            var copyInto = MemoryMarshal.CreateSpan(ref shiftInto, copyLen);

            copyFrom.CopyTo(copyInto);
        }
    }
}
