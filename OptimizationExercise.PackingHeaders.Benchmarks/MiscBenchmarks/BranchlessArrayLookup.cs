using BenchmarkDotNet.Attributes;
using OptimizationExercise.PackingHeaders.Benchmarks.Helpers;
using OptimizationExercise.PackingHeaders.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimizationExercise.PackingHeaders.Benchmarks.MiscBenchmarks
{
    public class BranchlessArrayLookup : MicroBenchmarkBase
    {
        private const int Iterations = 10_000;
        private HeaderNames[] HeaderNames = Array.Empty<HeaderNames>();
        private string?[] StoreInto = Array.Empty<string?>();

        private byte[] ArrayData = Array.Empty<byte>();
        private List<string?> ListData = new List<string?>();

        private byte[] ArrayDataWithNull = Array.Empty<byte>();
        private List<string?> ListDataWithNull = new List<string?>();

        [GlobalSetup]
        public override void GlobalSetup()
        {
            ArrayDataWithNull = new byte[Constants.HeaderNamesCount];
            ListDataWithNull.Add(null);

            ArrayData = new byte[Constants.HeaderNamesCount];

            HeaderNames = Data.Shuffle(Data.AllHeaders).ToArray();
            var headers = Data.ChooseNumberFrom(Data.AllHeaders, Constants.MaximumSetHeaders);
            foreach (var header in headers)
            {
                var val = "__" + header;

                ArrayData[(int)header] = (byte)ListData.Count;
                ListData.Add(val);

                ArrayDataWithNull[(int)header] = (byte)ListDataWithNull.Count;
                ListDataWithNull.Add(val);
            }

            StoreInto = new string?[HeaderNames.Length];
        }

        [Benchmark(Baseline = true)]
        public override void Naive()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Array.Clear(StoreInto);

                for (var j = 0; j < HeaderNames.Length; j++)
                {
                    var toLookup = HeaderNames[j];

                    string? value;
                    var ix = ArrayData[(int)toLookup];
                    if (ix == 0)
                    {
                        value = null;
                    }
                    else
                    {
                        value = ListData[ix];
                    }

                    StoreInto[j] = value;
                }
            }
        }

        [Benchmark]
        public override void Optimized()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Array.Clear(StoreInto);

                for (var j = 0; j < HeaderNames.Length; j++)
                {
                    var toLookup = HeaderNames[j];

                    string? value;
                    value = ListDataWithNull[ArrayDataWithNull[(int)toLookup]];

                    StoreInto[j] = value;
                }
            }
        }
    }
}
