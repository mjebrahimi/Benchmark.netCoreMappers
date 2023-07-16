```

BenchmarkDotNet v0.13.6, Windows 11 (10.0.22621.1848/22H2/2022Update/SunValley2)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.100-preview.5.23303.2
  [Host]     : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2
  Job-IHTMND : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2

RunStrategy=Throughput  

```
|        Method |       Mean |    Error |   StdDev |   Gen0 |   Gen1 | Allocated |
|-------------- |-----------:|---------:|---------:|-------:|-------:|----------:|
|   AgileMapper | 2,864.9 ns | 14.84 ns | 12.40 ns | 0.3777 |      - |    3160 B |
|               |            |          |          |        |        |           |
|    TinyMapper | 1,410.5 ns | 24.03 ns | 22.48 ns | 0.2575 |      - |    2160 B |
|               |            |          |          |        |        |           |
| ExpressMapper | 2,152.7 ns | 41.65 ns | 44.56 ns | 0.5836 | 0.0038 |    4904 B |
|               |            |          |          |        |        |           |
|    AutoMapper |   822.7 ns | 11.24 ns | 10.51 ns | 0.2270 | 0.0010 |    1904 B |
|               |            |          |          |        |        |           |
| ManualMapping |   306.2 ns |  6.12 ns | 15.80 ns | 0.1383 | 0.0005 |    1160 B |
|               |            |          |          |        |        |           |
|       Mapster |   242.0 ns |  4.18 ns |  7.96 ns | 0.2275 | 0.0014 |    1904 B |
|               |            |          |          |        |        |           |
|      Mapperly |   139.8 ns |  2.82 ns |  4.22 ns | 0.1099 | 0.0002 |     920 B |
