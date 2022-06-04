using BenchmarkDotNet.Attributes;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace OptimizationExercise.PackingHeaders.Benchmarks.MiscBenchmarks
{
    /// <summary>
    /// Benchmark comparing using a switch (with sequential values) to an Unsafe.Add.
    /// 
    /// Compares the 3 field and 10 field cases we actually have.
    /// </summary>
    public class UnsafeAddBenchmark : MicroBenchmarkBase
    {
        // crank this until benchmarkdotnet stops complaining
        private const int Iterations = 50_000_000;

        private PackedData tenFields;
        private PackedBitfield threeFields;

        private (byte Offset, string Value)[] TenFieldData = Array.Empty<(byte Offset, string Value)>();
        private (byte Offset, ulong Mask)[] ThreeFieldData = Array.Empty<(byte Offset, ulong Value)>();

        [Params(3, 10)]
        public int FieldCount { get; set; }

        [GlobalSetup]
        public override void GlobalSetup()
        {
            var rand = new Random(2022_06_05);

            switch (FieldCount)
            {
                case 3:
                    ThreeFieldData = Enumerable.Range(0, Iterations).Select(_ => (Offset: (byte)rand.Next(3), Value: (1UL << (byte)rand.Next(64)))).ToArray();
                    break;

                case 10:
                    var strings = RandomStrings(rand);
                    TenFieldData = Enumerable.Range(0, Iterations).Select(_ => (Offset: (byte)rand.Next(10), Value: strings[rand.Next(strings.Length)])).ToArray();
                    break;

                default:
                    throw new InvalidOperationException();
            }

            static string[] RandomStrings(Random rand)
            {
                var ret = new string[1000];
                var sb = new StringBuilder();
                for (var i = 0; i < ret.Length; i++)
                {
                    var len = rand.Next(50) + 1;

                    for (var j = 0; j < len; j++)
                    {
                        var c = (char)('A' + rand.Next(26));
                        if(rand.Next(2) == 1)
                        {
                            c = char.ToLowerInvariant(c);
                        }

                        sb.Append(c);
                    }

                    ret[i] = sb.ToString();
                    sb.Clear();
                }

                return ret;
            }
        }

        [IterationCleanup]
        public override void IterationSetup()
        {
            tenFields.data0 = "";
            tenFields.data1 = "";
            tenFields.data2 = "";
            tenFields.data3 = "";
            tenFields.data4 = "";
            tenFields.data5 = "";
            tenFields.data6 = "";
            tenFields.data7 = "";
            tenFields.data8 = "";
            tenFields.data9 = "";

            threeFields.bitfield0 = 0;
            threeFields.bitfield1 = 0;
            threeFields.bitfield2 = 0;
        }

        [Benchmark(Baseline = true)]
        public override void Naive()
        {
            switch(FieldCount)
            {
                case 3:
                    for(var i = 0; i < ThreeFieldData.Length; i++)
                    {
                        var data = ThreeFieldData[i];
                        switch (data.Offset)
                        {
                            case 0: threeFields.bitfield0 |= data.Mask; break;
                            case 1: threeFields.bitfield1 |= data.Mask; break;
                            case 2: threeFields.bitfield2 |= data.Mask; break;
                        }
                    }
                    break;
                case 10:
                    for (var i = 0; i < TenFieldData.Length; i++)
                    {
                        var data = TenFieldData[i];
                        switch (data.Offset)
                        {
                            case 0: tenFields.data0 = data.Value; break;
                            case 1: tenFields.data1 = data.Value; break;
                            case 2: tenFields.data2 = data.Value; break;
                            case 3: tenFields.data3 = data.Value; break;
                            case 4: tenFields.data4 = data.Value; break;
                            case 5: tenFields.data5 = data.Value; break;
                            case 6: tenFields.data6 = data.Value; break;
                            case 7: tenFields.data7 = data.Value; break;
                            case 8: tenFields.data8 = data.Value; break;
                            case 9: tenFields.data9 = data.Value; break;
                        }
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        [Benchmark]
        public override void Optimized()
        {
            switch (FieldCount)
            {
                case 3:
                    for (var i = 0; i < ThreeFieldData.Length; i++)
                    {
                        var data = ThreeFieldData[i];
                        ref ulong toUpdate = ref Unsafe.Add(ref threeFields.bitfield0, data.Offset);
                        toUpdate |= data.Mask;
                    }
                    break;
                case 10:
                    for (var i = 0; i < TenFieldData.Length; i++)
                    {
                        var data = TenFieldData[i];
                        ref string toUpdate = ref Unsafe.Add(ref tenFields.data0, data.Offset);
                        toUpdate = data.Value;
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
