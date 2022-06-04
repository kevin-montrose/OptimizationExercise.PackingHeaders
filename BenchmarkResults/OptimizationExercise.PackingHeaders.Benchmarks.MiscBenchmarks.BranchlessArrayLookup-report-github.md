``` ini

BenchmarkDotNet=v0.13.1.1796-nightly, OS=Microsoft Windows 10.0.25131 Microsoft Windows NT 10.0.25131.0
AMD Ryzen 7 Microsoft Surface Edition, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|    Method |     Mean |     Error |    StdDev | Ratio | RatioSD |
|---------- |---------:|----------:|----------:|------:|--------:|
|     Naive | 4.705 ms | 0.0884 ms | 0.0827 ms |  1.00 |    0.00 |
| Optimized | 4.322 ms | 0.0296 ms | 0.0247 ms |  0.92 |    0.02 |
