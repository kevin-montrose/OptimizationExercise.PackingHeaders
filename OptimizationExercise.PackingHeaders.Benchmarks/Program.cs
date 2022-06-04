using BenchmarkDotNet.Running;
using OptimizationExercise.PackingHeaders.Benchmarks;
using OptimizationExercise.PackingHeaders.Benchmarks.EnumerateBenchmarks;
using OptimizationExercise.PackingHeaders.Benchmarks.GetBenchmarks;
using OptimizationExercise.PackingHeaders.Benchmarks.MiscBenchmarks;
using OptimizationExercise.PackingHeaders.Benchmarks.SetBenchmarks;
using System;
using System.Diagnostics;

if (Debugger.IsAttached)
{
    CheckAllImpls<GetByEnumBenchmark>(static b => { b.NumHeadersSetParam = 5; });
    CheckAllImpls<GetDirectlyByNameBenchmark>(static b => { b.NumHeadersSetParam = 5; });
    CheckAllImpls<SetByEnumBenchmark>(static b => { b.OrderAndCount = new SetByEnumBenchmark.Parameters("Random", 5); });
    CheckAllImpls<SetDirectlyByNameBenchmark>(static b => { b.OrderAndCount = new SetDirectlyByNameBenchmark.Parameters("Random", 5); });
    CheckAllImpls<EnumeratorBenchmark>(static b => { b.NumHeadersSetParam = 5; });
    CheckAllImpls<CreateWithDictionaryBenchmark>(static b => { b.OrderAndCount = new CreateWithDictionaryBenchmark.Parameters("Random", 8); });

    CheckMicro<BranchlessArrayLookup>(static _ => { });
    CheckMicro<TrailingZeroCountBenchmark>(static b => b.OperandSizeBytes = sizeof(ushort));
    CheckMicro<TrailingZeroCountBenchmark>(static b => b.OperandSizeBytes = sizeof(uint));
    CheckMicro<TrailingZeroCountBenchmark>(static b => b.OperandSizeBytes = sizeof(ulong));
    CheckMicro<CountBitsBenchmark>(static _ => { });
    CheckMicro<BitsSetBeforeIndexBenchmark>(static _ => { });
    CheckMicro<UnsafeAddBenchmark>(static b => b.FieldCount = 3);
    CheckMicro<UnsafeAddBenchmark>(static b => b.FieldCount = 10);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 0);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 1);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 2);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 3);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 4);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 5);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 6);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 7);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 8);
    CheckMicro<ShiftFieldDownBenchmark>(static b => b.ShiftDownFromIndex = 9);
    CheckMicro<EnumeratingBitsBenchmark>(static b => b.NumBitsSet = 5);
    CheckMicro<BitfieldCalculationBenchmark>(static _ => { });
    CheckMicro<BitTestBenchmark>(static _ => { });
}
else
{
    BenchmarkSwitcher.FromAssembly(typeof(ImplBenchmarkBase).Assembly).Run();
}

static void CheckMicro<T>(Action<T> del)
    where T:MicroBenchmarkBase, new()
{
    Console.WriteLine($"[{DateTime.UtcNow:U}]: Starting {typeof(T).Name} check...");

    var benchmark = new T();
    del(benchmark);

    benchmark.GlobalSetup();

    benchmark.IterationSetup();
    benchmark.Naive();

    benchmark.IterationSetup();
    benchmark.Optimized();

    Console.WriteLine($"[{DateTime.UtcNow:U}]:\tfinished.");
}

static void CheckAllImpls<T>(Action<T> del)
    where T : ImplBenchmarkBase, new()
{
    Console.WriteLine($"[{DateTime.UtcNow:U}]: Starting {typeof(T).Name} check...");

    var benchmark = new T();
    del(benchmark);

    benchmark.GlobalSetup();

    benchmark.IterationSetup();
    benchmark.Dictionary();
    benchmark.IterationCleanup();

    benchmark.IterationSetup();
    benchmark.Fields_V1();
    benchmark.IterationCleanup();

    benchmark.IterationSetup();
    benchmark.Fields_V2();
    benchmark.IterationCleanup();

    benchmark.IterationSetup();
    benchmark.Arrays_V1();
    benchmark.IterationCleanup();

    benchmark.IterationSetup();
    benchmark.Arrays_V2();
    benchmark.IterationCleanup();

    benchmark.IterationSetup();
    benchmark.Packed_V1();
    benchmark.IterationCleanup();

    benchmark.IterationSetup();
    benchmark.Packed_V2();
    benchmark.IterationCleanup();

    benchmark.IterationSetup();
    benchmark.Packed_V3();
    benchmark.IterationCleanup();

    benchmark.IterationSetup();
    benchmark.Packed_V4();
    benchmark.IterationCleanup();

    benchmark.GlobalCleanup();

    Console.WriteLine($"[{DateTime.UtcNow:U}]:\tfinished.");
}