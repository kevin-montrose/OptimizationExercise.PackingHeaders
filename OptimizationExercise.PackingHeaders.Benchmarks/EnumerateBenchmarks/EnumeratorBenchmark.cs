using BenchmarkDotNet.Attributes;
using OptimizationExercise.PackingHeaders.ArrayImpl;
using OptimizationExercise.PackingHeaders.Benchmarks.Helpers;
using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.DictionaryImpl;
using OptimizationExercise.PackingHeaders.FieldsImpl;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimizationExercise.PackingHeaders.Benchmarks.EnumerateBenchmarks
{
    public class EnumeratorBenchmark : ImplBenchmarkBase
    {
        // have to pump up iterations until benchmarkdotnet stops complaining
        private const int Iterations = 1_000;

        [ParamsSource(nameof(NumHeadersSet))]
        public int NumHeadersSetParam { get; set; } = int.MaxValue;

        public static IEnumerable<int> NumHeadersSet => Enumerable.Range(0, Constants.MaximumSetHeaders + 1);

        private HeaderNames[] StoreInto = Array.Empty<HeaderNames>();

        private DictionaryHeaders dict = DictionaryHeaders.CreateEmpty();
        private FieldHeaders_V1 field_v1 = FieldHeaders_V1.CreateEmpty();
        private FieldHeaders_V2 field_v2 = FieldHeaders_V2.CreateEmpty();
        private ArrayHeaders_V1 array_v1 = ArrayHeaders_V1.CreateEmpty();
        private ArrayHeaders_V2 array_v2 = ArrayHeaders_V2.CreateEmpty();
        private PackedHeaders_V1 packed_v1 = PackedHeaders_V1.CreateEmpty();
        private PackedHeaders_V2 packed_v2 = PackedHeaders_V2.CreateEmpty();
        private PackedHeaders_V3 packed_v3 = PackedHeaders_V3.CreateEmpty();
        private PackedHeaders_V4 packed_v4 = PackedHeaders_V4.CreateEmpty();

        [GlobalSetup]
        public override void GlobalSetup()
        {
            var chosenHeaders = Data.PopulateAll(NumHeadersSetParam, ref dict, ref field_v1, ref field_v2, ref array_v1, ref array_v2, ref packed_v1, ref packed_v2, ref packed_v3, ref packed_v4);

            StoreInto = new HeaderNames[chosenHeaders.Length];
        }

        [Benchmark]
        public override void Arrays_V1()
        => RunBenchmark<ArrayHeaders_V1, ArrayHeaders_V1.Enumerator>(array_v1);

        [Benchmark]
        public override void Arrays_V2()
        => RunBenchmark<ArrayHeaders_V2, ArrayHeaders_V2.Enumerator>(array_v2);

        [Benchmark]
        public override void Dictionary()
        => RunBenchmark<DictionaryHeaders, Dictionary<HeaderNames, string>.KeyCollection.Enumerator>(dict);

        [Benchmark]
        public override void Fields_V1()
        => RunBenchmark<FieldHeaders_V1, FieldHeaders_V1.Enumerator>(field_v1);

        [Benchmark]
        public override void Fields_V2()
        => RunBenchmark<FieldHeaders_V2, FieldHeaders_V2.Enumerator>(field_v2);

        [Benchmark]
        public override void Packed_V1()
        => RunBenchmark<PackedHeaders_V1, PackedHeaders_V1.Enumerator>(packed_v1);

        [Benchmark]
        public override void Packed_V2()
        => RunBenchmark<PackedHeaders_V2, PackedHeaders_V2.Enumerator>(packed_v2);

        [Benchmark]
        public override void Packed_V3()
        => RunBenchmark<PackedHeaders_V3, PackedHeaders_V3.Enumerator>(packed_v3);

        [Benchmark]
        public override void Packed_V4()
        => RunBenchmark<PackedHeaders_V4, PackedHeaders_V4.Enumerator>(packed_v4);

        private void RunBenchmark<T, V>(T headers)
            where T : IHeadersStructure<T, V>
            where V : struct, IEnumerator<HeaderNames>
        {
            for (var iter = 0; iter < Iterations; iter++)
            {
                Array.Clear(StoreInto);

                var nextIx = 0;
                foreach(var name in headers)
                {
                    StoreInto[nextIx] = name;
                    nextIx++;
                }
            }
        }
    }
}
