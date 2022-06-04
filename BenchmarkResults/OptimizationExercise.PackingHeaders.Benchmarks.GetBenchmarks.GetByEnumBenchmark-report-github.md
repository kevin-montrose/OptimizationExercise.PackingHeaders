``` ini

BenchmarkDotNet=v0.13.1.1796-nightly, OS=Microsoft Windows 10.0.25131 Microsoft Windows NT 10.0.25131.0
AMD Ryzen 7 Microsoft Surface Edition, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|     Method | NumHeadersSetParam |      Mean |    Error |   StdDev |
|----------- |------------------- |----------:|---------:|---------:|
| **Dictionary** |                  **0** | **108.46 ms** | **0.327 ms** | **0.273 ms** |
|  Fields_V1 |                  0 | 200.96 ms | 0.988 ms | 0.924 ms |
|  Fields_V2 |                  0 |  68.21 ms | 0.252 ms | 0.211 ms |
|  Arrays_V1 |                  0 |  73.43 ms | 0.608 ms | 0.539 ms |
|  Arrays_V2 |                  0 |  73.39 ms | 0.305 ms | 0.270 ms |
|  Packed_V1 |                  0 |  84.14 ms | 0.641 ms | 0.600 ms |
|  Packed_V2 |                  0 |  72.45 ms | 0.424 ms | 0.354 ms |
|  Packed_V3 |                  0 |  72.40 ms | 0.399 ms | 0.373 ms |
|  Packed_V4 |                  0 |  63.85 ms | 0.475 ms | 0.445 ms |
| **Dictionary** |                  **1** | **141.06 ms** | **0.694 ms** | **0.649 ms** |
|  Fields_V1 |                  1 | 205.31 ms | 0.460 ms | 0.430 ms |
|  Fields_V2 |                  1 |  73.54 ms | 0.214 ms | 0.190 ms |
|  Arrays_V1 |                  1 |  74.58 ms | 0.233 ms | 0.218 ms |
|  Arrays_V2 |                  1 |  74.67 ms | 0.284 ms | 0.266 ms |
|  Packed_V1 |                  1 |  83.24 ms | 0.233 ms | 0.194 ms |
|  Packed_V2 |                  1 |  72.04 ms | 0.221 ms | 0.185 ms |
|  Packed_V3 |                  1 |  73.91 ms | 0.243 ms | 0.203 ms |
|  Packed_V4 |                  1 |  65.73 ms | 0.190 ms | 0.177 ms |
| **Dictionary** |                  **2** | **147.19 ms** | **0.542 ms** | **0.481 ms** |
|  Fields_V1 |                  2 | 202.92 ms | 1.260 ms | 1.178 ms |
|  Fields_V2 |                  2 |  75.28 ms | 0.303 ms | 0.236 ms |
|  Arrays_V1 |                  2 |  76.61 ms | 0.461 ms | 0.385 ms |
|  Arrays_V2 |                  2 |  76.77 ms | 0.346 ms | 0.270 ms |
|  Packed_V1 |                  2 |  85.94 ms | 0.621 ms | 0.581 ms |
|  Packed_V2 |                  2 |  75.08 ms | 0.263 ms | 0.246 ms |
|  Packed_V3 |                  2 |  72.39 ms | 0.202 ms | 0.169 ms |
|  Packed_V4 |                  2 |  67.66 ms | 0.159 ms | 0.141 ms |
| **Dictionary** |                  **3** | **149.63 ms** | **0.396 ms** | **0.351 ms** |
|  Fields_V1 |                  3 | 205.51 ms | 0.354 ms | 0.331 ms |
|  Fields_V2 |                  3 |  75.94 ms | 0.195 ms | 0.182 ms |
|  Arrays_V1 |                  3 |  77.31 ms | 0.188 ms | 0.176 ms |
|  Arrays_V2 |                  3 |  77.37 ms | 0.264 ms | 0.220 ms |
|  Packed_V1 |                  3 |  88.57 ms | 0.349 ms | 0.309 ms |
|  Packed_V2 |                  3 |  78.37 ms | 0.279 ms | 0.261 ms |
|  Packed_V3 |                  3 |  73.19 ms | 0.263 ms | 0.233 ms |
|  Packed_V4 |                  3 |  68.56 ms | 0.244 ms | 0.216 ms |
| **Dictionary** |                  **4** | **147.58 ms** | **0.588 ms** | **0.491 ms** |
|  Fields_V1 |                  4 | 204.00 ms | 0.481 ms | 0.427 ms |
|  Fields_V2 |                  4 |  77.52 ms | 0.282 ms | 0.220 ms |
|  Arrays_V1 |                  4 |  79.22 ms | 0.187 ms | 0.166 ms |
|  Arrays_V2 |                  4 |  79.82 ms | 1.145 ms | 1.071 ms |
|  Packed_V1 |                  4 |  89.87 ms | 0.426 ms | 0.378 ms |
|  Packed_V2 |                  4 |  79.80 ms | 0.329 ms | 0.292 ms |
|  Packed_V3 |                  4 |  74.08 ms | 0.309 ms | 0.258 ms |
|  Packed_V4 |                  4 |  69.43 ms | 0.216 ms | 0.181 ms |
| **Dictionary** |                  **5** | **148.53 ms** | **0.322 ms** | **0.269 ms** |
|  Fields_V1 |                  5 | 199.25 ms | 0.973 ms | 0.910 ms |
|  Fields_V2 |                  5 |  77.92 ms | 0.174 ms | 0.145 ms |
|  Arrays_V1 |                  5 |  79.37 ms | 0.268 ms | 0.224 ms |
|  Arrays_V2 |                  5 |  80.21 ms | 1.149 ms | 1.075 ms |
|  Packed_V1 |                  5 |  90.42 ms | 0.248 ms | 0.220 ms |
|  Packed_V2 |                  5 |  80.78 ms | 0.576 ms | 0.539 ms |
|  Packed_V3 |                  5 |  74.43 ms | 0.296 ms | 0.231 ms |
|  Packed_V4 |                  5 |  70.09 ms | 0.661 ms | 0.618 ms |
| **Dictionary** |                  **6** | **147.90 ms** | **0.547 ms** | **0.427 ms** |
|  Fields_V1 |                  6 | 202.85 ms | 0.456 ms | 0.426 ms |
|  Fields_V2 |                  6 |  78.96 ms | 0.175 ms | 0.146 ms |
|  Arrays_V1 |                  6 |  80.82 ms | 0.461 ms | 0.385 ms |
|  Arrays_V2 |                  6 |  81.52 ms | 1.627 ms | 1.522 ms |
|  Packed_V1 |                  6 |  91.80 ms | 0.415 ms | 0.368 ms |
|  Packed_V2 |                  6 |  82.70 ms | 0.227 ms | 0.177 ms |
|  Packed_V3 |                  6 |  76.91 ms | 0.768 ms | 0.718 ms |
|  Packed_V4 |                  6 |  71.42 ms | 0.304 ms | 0.238 ms |
| **Dictionary** |                  **7** | **149.79 ms** | **0.476 ms** | **0.398 ms** |
|  Fields_V1 |                  7 | 201.24 ms | 0.266 ms | 0.208 ms |
|  Fields_V2 |                  7 |  76.70 ms | 0.944 ms | 0.883 ms |
|  Arrays_V1 |                  7 |  81.79 ms | 0.376 ms | 0.294 ms |
|  Arrays_V2 |                  7 |  82.05 ms | 0.283 ms | 0.236 ms |
|  Packed_V1 |                  7 |  94.52 ms | 0.260 ms | 0.244 ms |
|  Packed_V2 |                  7 |  84.25 ms | 0.291 ms | 0.272 ms |
|  Packed_V3 |                  7 |  77.27 ms | 0.237 ms | 0.222 ms |
|  Packed_V4 |                  7 |  72.27 ms | 0.282 ms | 0.264 ms |
| **Dictionary** |                  **8** | **152.58 ms** | **0.478 ms** | **0.399 ms** |
|  Fields_V1 |                  8 | 200.01 ms | 0.435 ms | 0.407 ms |
|  Fields_V2 |                  8 |  80.71 ms | 0.236 ms | 0.221 ms |
|  Arrays_V1 |                  8 |  82.56 ms | 0.217 ms | 0.203 ms |
|  Arrays_V2 |                  8 |  82.57 ms | 0.176 ms | 0.165 ms |
|  Packed_V1 |                  8 |  97.34 ms | 0.406 ms | 0.379 ms |
|  Packed_V2 |                  8 |  87.15 ms | 0.188 ms | 0.176 ms |
|  Packed_V3 |                  8 |  79.50 ms | 0.300 ms | 0.266 ms |
|  Packed_V4 |                  8 |  74.11 ms | 0.187 ms | 0.175 ms |
| **Dictionary** |                  **9** | **154.81 ms** | **0.471 ms** | **0.441 ms** |
|  Fields_V1 |                  9 | 200.35 ms | 0.533 ms | 0.498 ms |
|  Fields_V2 |                  9 |  81.58 ms | 0.242 ms | 0.226 ms |
|  Arrays_V1 |                  9 |  83.87 ms | 0.290 ms | 0.272 ms |
|  Arrays_V2 |                  9 |  83.85 ms | 0.084 ms | 0.075 ms |
|  Packed_V1 |                  9 |  99.44 ms | 0.251 ms | 0.222 ms |
|  Packed_V2 |                  9 |  88.78 ms | 0.236 ms | 0.221 ms |
|  Packed_V3 |                  9 |  79.76 ms | 0.201 ms | 0.188 ms |
|  Packed_V4 |                  9 |  74.42 ms | 0.335 ms | 0.313 ms |
| **Dictionary** |                 **10** | **152.79 ms** | **0.998 ms** | **0.933 ms** |
|  Fields_V1 |                 10 | 198.32 ms | 0.492 ms | 0.436 ms |
|  Fields_V2 |                 10 |  82.84 ms | 0.233 ms | 0.218 ms |
|  Arrays_V1 |                 10 |  85.20 ms | 0.250 ms | 0.234 ms |
|  Arrays_V2 |                 10 |  85.20 ms | 0.366 ms | 0.325 ms |
|  Packed_V1 |                 10 |  99.86 ms | 0.438 ms | 0.410 ms |
|  Packed_V2 |                 10 |  90.40 ms | 0.583 ms | 0.546 ms |
|  Packed_V3 |                 10 |  80.81 ms | 0.324 ms | 0.253 ms |
|  Packed_V4 |                 10 |  75.98 ms | 0.717 ms | 0.670 ms |
