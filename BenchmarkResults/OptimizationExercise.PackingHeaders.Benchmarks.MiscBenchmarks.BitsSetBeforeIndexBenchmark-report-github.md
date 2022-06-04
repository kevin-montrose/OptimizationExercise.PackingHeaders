``` ini

BenchmarkDotNet=v0.13.1.1796-nightly, OS=Microsoft Windows 10.0.25131 Microsoft Windows NT 10.0.25131.0
AMD Ryzen 7 Microsoft Surface Edition, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  Job-ZWQPOU : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|    Method |     Mean |   Error |  StdDev | Ratio |
|---------- |---------:|--------:|--------:|------:|
|     Naive | 292.8 ms | 0.71 ms | 0.66 ms |  1.00 |
| Optimized | 103.8 ms | 0.44 ms | 0.39 ms |  0.35 |
