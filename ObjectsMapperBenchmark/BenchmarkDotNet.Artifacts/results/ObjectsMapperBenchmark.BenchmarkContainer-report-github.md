```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3007/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700, 1 CPU, 20 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
  Job-DJCFIR : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2

RunStrategy=Throughput  

```
| Method        | Mean       | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|-------------- |-----------:|---------:|---------:|-------:|-------:|----------:|
| Mapperly      |   107.8 ns |  2.14 ns |  2.29 ns | 0.0703 | 0.0002 |     920 B |
| Mapster       |   205.7 ns |  4.08 ns |  8.69 ns | 0.1457 | 0.0010 |    1904 B |
| ManualMapping |   256.1 ns |  5.08 ns |  6.96 ns | 0.0887 |      - |    1160 B |
| AutoMapper    |   463.8 ns |  9.22 ns | 10.25 ns | 0.1454 | 0.0010 |    1904 B |
| TinyMapper    |   903.1 ns |  7.70 ns |  7.20 ns | 0.1650 |      - |    2160 B |
| ExpressMapper | 1,356.3 ns | 18.84 ns | 16.70 ns | 0.3738 | 0.0019 |    4904 B |
| AgileMapper   | 1,624.8 ns | 19.11 ns | 16.94 ns | 0.2403 |      - |    3160 B |
