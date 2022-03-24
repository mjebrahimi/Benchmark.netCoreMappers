``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1586 (21H1/May2021Update)
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  Job-RITSVR : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

RunStrategy=Throughput  

```
|            Method |       Mean |    Error |   StdDev |  Gen 0 | Allocated |
|------------------ |-----------:|---------:|---------:|-------:|----------:|
|       AgileMapper | 2,280.0 ns | 19.41 ns | 17.21 ns | 1.0071 |   3,160 B |
|                   |            |          |          |        |           |
|        TinyMapper | 3,652.3 ns | 32.21 ns | 30.13 ns | 0.6866 |   2,160 B |
|                   |            |          |          |        |           |
|     ExpressMapper | 3,198.6 ns | 42.70 ns | 39.94 ns | 1.5602 |   4,904 B |
|                   |            |          |          |        |           |
|        AutoMapper | 1,572.2 ns | 11.23 ns |  9.95 ns | 0.6065 |   1,904 B |
|                   |            |          |          |        |           |
|     ManualMapping |   453.9 ns |  3.12 ns |  2.77 ns | 0.3695 |   1,160 B |
|                   |            |          |          |        |           |
|           Mapster |   453.9 ns |  5.31 ns |  4.43 ns | 0.6065 |   1,904 B |
|                   |            |          |          |        |           |
|          Mapperly |   278.3 ns |  2.76 ns |  2.58 ns | 0.2933 |     920 B |
|                   |            |          |          |        |           |
| HypercubusMapping |   407.4 ns |  5.32 ns |  4.98 ns | 0.2933 |     920 B |
