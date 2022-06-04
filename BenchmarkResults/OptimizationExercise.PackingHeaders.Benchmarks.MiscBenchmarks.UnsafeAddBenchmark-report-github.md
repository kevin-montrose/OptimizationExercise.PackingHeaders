``` ini

BenchmarkDotNet=v0.13.1.1796-nightly, OS=Microsoft Windows 10.0.25131 Microsoft Windows NT 10.0.25131.0
AMD Ryzen 7 Microsoft Surface Edition, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  Job-ZWQPOU : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|    Method | FieldCount |     Mean |   Error |  StdDev | Ratio |
|---------- |----------- |---------:|--------:|--------:|------:|
|     **Naive** |          **3** | **461.3 ms** | **1.94 ms** | **1.62 ms** |  **1.00** |
| Optimized |          3 | 103.9 ms | 0.82 ms | 0.77 ms |  0.23 |
|           |            |          |         |         |       |
|     **Naive** |         **10** | **464.9 ms** | **1.71 ms** | **1.60 ms** |  **1.00** |
| Optimized |         10 | 101.6 ms | 0.84 ms | 0.78 ms |  0.22 |
