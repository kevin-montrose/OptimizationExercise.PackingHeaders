``` ini

BenchmarkDotNet=v0.13.1.1796-nightly, OS=Microsoft Windows 10.0.25131 Microsoft Windows NT 10.0.25131.0
AMD Ryzen 7 Microsoft Surface Edition, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  Job-ZWQPOU : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|    Method | OperandSizeBytes |      Mean |    Error |   StdDev | Ratio |
|---------- |----------------- |----------:|---------:|---------:|------:|
|     **Naive** |                **2** | **400.48 ms** | **6.970 ms** | **6.519 ms** |  **1.00** |
| Optimized |                2 |  73.75 ms | 0.828 ms | 0.734 ms |  0.18 |
|           |                  |           |          |          |       |
|     **Naive** |                **4** | **462.80 ms** | **2.806 ms** | **2.625 ms** |  **1.00** |
| Optimized |                4 |  78.07 ms | 0.690 ms | 0.646 ms |  0.17 |
|           |                  |           |          |          |       |
|     **Naive** |                **8** | **599.75 ms** | **1.196 ms** | **1.119 ms** |  **1.00** |
| Optimized |                8 |  85.07 ms | 0.655 ms | 0.613 ms |  0.14 |
