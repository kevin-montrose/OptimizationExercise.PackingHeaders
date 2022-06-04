``` ini

BenchmarkDotNet=v0.13.1.1796-nightly, OS=Microsoft Windows 10.0.25131 Microsoft Windows NT 10.0.25131.0
AMD Ryzen 7 Microsoft Surface Edition, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|     Method | NumHeadersSetParam |      Mean |    Error |   StdDev |
|----------- |------------------- |----------:|---------:|---------:|
| **Dictionary** |                  **0** | **152.79 ms** | **0.271 ms** | **0.240 ms** |
|  Fields_V1 |                  0 |  92.48 ms | 0.166 ms | 0.155 ms |
|  Fields_V2 |                  0 |  92.26 ms | 0.111 ms | 0.099 ms |
|  Arrays_V1 |                  0 |  91.37 ms | 0.166 ms | 0.155 ms |
|  Arrays_V2 |                  0 |  91.47 ms | 0.147 ms | 0.137 ms |
|  Packed_V1 |                  0 | 111.74 ms | 0.260 ms | 0.231 ms |
|  Packed_V2 |                  0 | 112.50 ms | 0.544 ms | 0.508 ms |
|  Packed_V3 |                  0 | 109.36 ms | 0.564 ms | 0.527 ms |
|  Packed_V4 |                  0 | 109.72 ms | 0.186 ms | 0.145 ms |
| **Dictionary** |                  **1** | **169.88 ms** | **0.742 ms** | **0.658 ms** |
|  Fields_V1 |                  1 |  90.59 ms | 0.176 ms | 0.156 ms |
|  Fields_V2 |                  1 |  90.53 ms | 0.297 ms | 0.278 ms |
|  Arrays_V1 |                  1 |  95.37 ms | 0.826 ms | 0.773 ms |
|  Arrays_V2 |                  1 |  95.33 ms | 0.561 ms | 0.525 ms |
|  Packed_V1 |                  1 | 112.76 ms | 0.406 ms | 0.380 ms |
|  Packed_V2 |                  1 | 113.10 ms | 0.707 ms | 0.661 ms |
|  Packed_V3 |                  1 | 112.44 ms | 0.662 ms | 0.619 ms |
|  Packed_V4 |                  1 | 105.13 ms | 0.256 ms | 0.227 ms |
| **Dictionary** |                  **2** | **181.88 ms** | **0.911 ms** | **0.853 ms** |
|  Fields_V1 |                  2 |  91.02 ms | 0.315 ms | 0.295 ms |
|  Fields_V2 |                  2 |  91.12 ms | 0.480 ms | 0.449 ms |
|  Arrays_V1 |                  2 |  95.39 ms | 0.411 ms | 0.385 ms |
|  Arrays_V2 |                  2 |  95.66 ms | 0.471 ms | 0.441 ms |
|  Packed_V1 |                  2 | 113.36 ms | 0.255 ms | 0.238 ms |
|  Packed_V2 |                  2 | 110.77 ms | 0.575 ms | 0.510 ms |
|  Packed_V3 |                  2 | 112.86 ms | 0.568 ms | 0.531 ms |
|  Packed_V4 |                  2 | 105.46 ms | 0.278 ms | 0.260 ms |
| **Dictionary** |                  **3** | **182.35 ms** | **1.066 ms** | **0.997 ms** |
|  Fields_V1 |                  3 |  90.98 ms | 0.282 ms | 0.250 ms |
|  Fields_V2 |                  3 |  91.15 ms | 0.248 ms | 0.232 ms |
|  Arrays_V1 |                  3 |  98.12 ms | 0.467 ms | 0.437 ms |
|  Arrays_V2 |                  3 |  95.32 ms | 0.256 ms | 0.214 ms |
|  Packed_V1 |                  3 | 112.06 ms | 0.494 ms | 0.438 ms |
|  Packed_V2 |                  3 | 112.02 ms | 0.791 ms | 0.740 ms |
|  Packed_V3 |                  3 | 113.27 ms | 0.643 ms | 0.602 ms |
|  Packed_V4 |                  3 | 105.83 ms | 0.508 ms | 0.476 ms |
| **Dictionary** |                  **4** | **179.72 ms** | **0.685 ms** | **0.607 ms** |
|  Fields_V1 |                  4 |  91.48 ms | 0.379 ms | 0.354 ms |
|  Fields_V2 |                  4 |  91.30 ms | 0.266 ms | 0.249 ms |
|  Arrays_V1 |                  4 |  95.47 ms | 0.262 ms | 0.232 ms |
|  Arrays_V2 |                  4 |  95.28 ms | 0.195 ms | 0.182 ms |
|  Packed_V1 |                  4 | 111.83 ms | 0.231 ms | 0.216 ms |
|  Packed_V2 |                  4 | 115.38 ms | 0.211 ms | 0.187 ms |
|  Packed_V3 |                  4 | 113.21 ms | 0.319 ms | 0.298 ms |
|  Packed_V4 |                  4 | 105.70 ms | 0.286 ms | 0.267 ms |
| **Dictionary** |                  **5** | **177.47 ms** | **1.182 ms** | **1.106 ms** |
|  Fields_V1 |                  5 |  91.37 ms | 0.277 ms | 0.245 ms |
|  Fields_V2 |                  5 |  91.43 ms | 0.247 ms | 0.231 ms |
|  Arrays_V1 |                  5 |  95.47 ms | 0.224 ms | 0.210 ms |
|  Arrays_V2 |                  5 |  95.54 ms | 0.213 ms | 0.199 ms |
|  Packed_V1 |                  5 | 112.46 ms | 0.471 ms | 0.393 ms |
|  Packed_V2 |                  5 | 112.24 ms | 0.271 ms | 0.254 ms |
|  Packed_V3 |                  5 | 110.46 ms | 0.284 ms | 0.266 ms |
|  Packed_V4 |                  5 | 108.13 ms | 0.155 ms | 0.145 ms |
| **Dictionary** |                  **6** | **184.59 ms** | **0.505 ms** | **0.473 ms** |
|  Fields_V1 |                  6 |  91.39 ms | 0.145 ms | 0.129 ms |
|  Fields_V2 |                  6 |  91.44 ms | 0.103 ms | 0.092 ms |
|  Arrays_V1 |                  6 |  95.52 ms | 0.215 ms | 0.201 ms |
|  Arrays_V2 |                  6 |  95.65 ms | 0.292 ms | 0.273 ms |
|  Packed_V1 |                  6 | 115.10 ms | 0.213 ms | 0.189 ms |
|  Packed_V2 |                  6 | 116.16 ms | 0.202 ms | 0.189 ms |
|  Packed_V3 |                  6 | 115.40 ms | 0.263 ms | 0.233 ms |
|  Packed_V4 |                  6 | 105.97 ms | 0.149 ms | 0.124 ms |
| **Dictionary** |                  **7** | **175.56 ms** | **0.480 ms** | **0.449 ms** |
|  Fields_V1 |                  7 |  91.19 ms | 0.105 ms | 0.098 ms |
|  Fields_V2 |                  7 |  91.23 ms | 0.124 ms | 0.116 ms |
|  Arrays_V1 |                  7 |  95.82 ms | 0.183 ms | 0.171 ms |
|  Arrays_V2 |                  7 |  95.66 ms | 0.124 ms | 0.116 ms |
|  Packed_V1 |                  7 | 113.22 ms | 0.200 ms | 0.177 ms |
|  Packed_V2 |                  7 | 116.70 ms | 0.195 ms | 0.182 ms |
|  Packed_V3 |                  7 | 119.46 ms | 0.163 ms | 0.136 ms |
|  Packed_V4 |                  7 | 105.85 ms | 0.250 ms | 0.234 ms |
| **Dictionary** |                  **8** | **181.13 ms** | **0.349 ms** | **0.326 ms** |
|  Fields_V1 |                  8 |  91.48 ms | 0.089 ms | 0.083 ms |
|  Fields_V2 |                  8 |  91.13 ms | 0.113 ms | 0.100 ms |
|  Arrays_V1 |                  8 |  95.79 ms | 0.253 ms | 0.224 ms |
|  Arrays_V2 |                  8 |  95.64 ms | 0.144 ms | 0.128 ms |
|  Packed_V1 |                  8 | 116.91 ms | 0.152 ms | 0.142 ms |
|  Packed_V2 |                  8 | 117.08 ms | 0.199 ms | 0.177 ms |
|  Packed_V3 |                  8 | 115.96 ms | 0.214 ms | 0.179 ms |
|  Packed_V4 |                  8 | 105.81 ms | 0.153 ms | 0.143 ms |
| **Dictionary** |                  **9** | **177.99 ms** | **0.462 ms** | **0.409 ms** |
|  Fields_V1 |                  9 |  94.18 ms | 0.231 ms | 0.205 ms |
|  Fields_V2 |                  9 |  91.77 ms | 0.279 ms | 0.261 ms |
|  Arrays_V1 |                  9 |  96.39 ms | 0.637 ms | 0.596 ms |
|  Arrays_V2 |                  9 |  96.05 ms | 0.285 ms | 0.252 ms |
|  Packed_V1 |                  9 | 118.36 ms | 0.837 ms | 0.783 ms |
|  Packed_V2 |                  9 | 114.95 ms | 0.583 ms | 0.545 ms |
|  Packed_V3 |                  9 | 114.32 ms | 0.500 ms | 0.468 ms |
|  Packed_V4 |                  9 | 105.91 ms | 0.157 ms | 0.139 ms |
| **Dictionary** |                 **10** | **179.22 ms** | **0.360 ms** | **0.337 ms** |
|  Fields_V1 |                 10 |  91.73 ms | 0.118 ms | 0.111 ms |
|  Fields_V2 |                 10 |  91.44 ms | 0.184 ms | 0.172 ms |
|  Arrays_V1 |                 10 |  95.96 ms | 0.195 ms | 0.182 ms |
|  Arrays_V2 |                 10 |  95.91 ms | 0.160 ms | 0.150 ms |
|  Packed_V1 |                 10 | 116.51 ms | 0.431 ms | 0.403 ms |
|  Packed_V2 |                 10 | 116.75 ms | 0.210 ms | 0.196 ms |
|  Packed_V3 |                 10 | 110.72 ms | 0.178 ms | 0.167 ms |
|  Packed_V4 |                 10 | 106.15 ms | 0.176 ms | 0.164 ms |
