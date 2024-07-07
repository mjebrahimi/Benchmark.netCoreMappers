using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using BenchmarkDotNetVisualizer;
using ObjectsMapperBenchmark;

var config = BenchmarkAutoRunner.IsRunningInDebugMode() ? new DebugInProcessConfigDry() : DefaultConfig.Instance;
config = config.WithOptions(ConfigOptions.DisableOptimizationsValidator); //because AgileObjects.AgileMapper is built non-optimized

var summary = BenchmarkRunner.Run<Benchmark>(config, args);

await summary.SaveAsImageAsync(
    path: DirectoryHelper.GetPathRelativeToProjectDirectory("Benchmark.png"),
    options: new ReportImageOptions
    {
        Title = "🥇.NET Object Mappers Benchmark",
        DividerMode = RenderTableDividerMode.EmptyDividerRow,
        GroupByColumns = ["Categories"],
        SortByColumns = ["Mean", "Allocated",],
        SpectrumColumns = ["Mean", "Allocated",],
        HighlightGroups = true,
    });
