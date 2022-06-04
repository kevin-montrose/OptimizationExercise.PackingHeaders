``` ini

BenchmarkDotNet=v0.13.1.1796-nightly, OS=Microsoft Windows 10.0.25131 Microsoft Windows NT 10.0.25131.0
AMD Ryzen 7 Microsoft Surface Edition, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  Job-ZWQPOU : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|    Method | ShiftDownFromIndex |       Mean |    Error |   StdDev | Ratio |
|---------- |------------------- |-----------:|---------:|---------:|------:|
|     **Naive** |                  **0** | **3,311.8 ms** | **27.74 ms** | **24.59 ms** |  **1.00** |
| Optimized |                  0 | 1,968.6 ms | 25.77 ms | 24.10 ms |  0.59 |
|           |                    |            |          |          |       |
|     **Naive** |                  **1** | **2,956.3 ms** | **16.54 ms** | **15.47 ms** |  **1.00** |
| Optimized |                  1 | 1,710.6 ms | 18.86 ms | 17.64 ms |  0.58 |
|           |                    |            |          |          |       |
|     **Naive** |                  **2** | **2,666.5 ms** | **15.31 ms** | **14.32 ms** |  **1.00** |
| Optimized |                  2 | 1,922.3 ms |  1.84 ms |  1.63 ms |  0.72 |
|           |                    |            |          |          |       |
|     **Naive** |                  **3** | **2,419.4 ms** |  **0.93 ms** |  **0.83 ms** |  **1.00** |
| Optimized |                  3 | 1,517.8 ms |  2.68 ms |  2.51 ms |  0.63 |
|           |                    |            |          |          |       |
|     **Naive** |                  **4** | **2,085.5 ms** | **11.40 ms** | **10.67 ms** |  **1.00** |
| Optimized |                  4 | 1,645.1 ms |  2.98 ms |  2.33 ms |  0.79 |
|           |                    |            |          |          |       |
|     **Naive** |                  **5** | **1,796.8 ms** |  **9.49 ms** |  **8.88 ms** |  **1.00** |
| Optimized |                  5 | 1,584.8 ms |  8.31 ms |  6.49 ms |  0.88 |
|           |                    |            |          |          |       |
|     **Naive** |                  **6** | **1,443.6 ms** |  **2.16 ms** |  **1.81 ms** |  **1.00** |
| Optimized |                  6 | 1,441.5 ms |  0.86 ms |  0.80 ms |  1.00 |
|           |                    |            |          |          |       |
|     **Naive** |                  **7** | **1,209.6 ms** |  **0.63 ms** |  **0.49 ms** |  **1.00** |
| Optimized |                  7 | 1,268.3 ms |  0.89 ms |  0.79 ms |  1.05 |
|           |                    |            |          |          |       |
|     **Naive** |                  **8** |   **806.7 ms** |  **0.56 ms** |  **0.53 ms** |  **1.00** |
| Optimized |                  8 |   926.9 ms |  5.23 ms |  4.90 ms |  1.15 |
|           |                    |            |          |          |       |
|     **Naive** |                  **9** |   **519.5 ms** |  **0.88 ms** |  **0.69 ms** |  **1.00** |
| Optimized |                  9 |   579.3 ms |  2.76 ms |  2.58 ms |  1.11 |
