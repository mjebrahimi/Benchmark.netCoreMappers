using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using BenchmarkDotNetVisualizer;
using ObjectsMapperBenchmark;
using System;
using System.Diagnostics;
using System.Threading;

ValidateRuntime();

var config = BenchmarkAutoRunner.IsRunningInDebugMode() ? new DebugInProcessConfigDry() : DefaultConfig.Instance;
config = config.WithOptions(ConfigOptions.DisableOptimizationsValidator); //because AgileObjects.AgileMapper is built non-optimized
var summary = BenchmarkRunner.Run<BenchmarkContainer>(config, args);

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

static void ValidateRuntime()
{
    if (BenchmarkAutoRunner.IsRunningInDebugMode())
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You are in DEBUG mode. To achieve accurate results, set project configuration to RELEASE mode.");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Please wait 3 seconds to enter DEBUG mode");

        Thread.Sleep(3000);
    }
    else if (Debugger.IsAttached)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Debugger is Attached. To achieve accurate results, run project without Debugger.");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Or if you want to Debug project, set project configuration to DEBUG mode.");

        Console.ForegroundColor = ConsoleColor.White;
        Environment.Exit(0);
    }
}