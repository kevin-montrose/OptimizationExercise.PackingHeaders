``` ini

BenchmarkDotNet=v0.13.1.1796-nightly, OS=Microsoft Windows 10.0.25131 Microsoft Windows NT 10.0.25131.0
AMD Ryzen 7 Microsoft Surface Edition, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|    Method |     Mean |    Error |   StdDev | Ratio |
|---------- |---------:|---------:|---------:|------:|
|     Naive | 62.50 ms | 0.344 ms | 0.322 ms |  1.00 |
| Optimized | 52.99 ms | 0.261 ms | 0.244 ms |  0.85 |
