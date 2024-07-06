using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using BenchmarkDotNetVisualizer;
using ObjectsMapperBenchmark;

var config = BenchmarkAutoRunner.IsRunningInDebugMode() ? new DebugInProcessConfigDry() : DefaultConfig.Instance;
config = config.WithOptions(ConfigOptions.DisableOptimizationsValidator); //because AgileObjects.AgileMapper is built non-optimized
var summary = BenchmarkRunner.Run<Benchmark>(config, args);

var path = DirectoryHelper.GetPathRelativeToProjectDirectory("Benchmark.png");
await summary.SaveAsImageAsync(path, new ReportImageOptions
{
    Title = "🥇.NET Object Mappers Benchmark",
    SortByColumns = ["Mean", "Allocated",],
    SpectrumColumns = ["Mean", "Allocated",],
    GroupByColumns = [],
    HighlightGroups = false,
    DividerMode = RenderTableDividerMode.EmptyDividerRow,
});