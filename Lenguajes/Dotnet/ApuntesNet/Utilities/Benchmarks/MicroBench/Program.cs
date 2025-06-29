using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;
using MicroBench;

ManualConfig config = ManualConfig
    .Create(DefaultConfig.Instance)
    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    .AddExporter(MarkdownExporter.Console);

BenchmarkRunner.Run(
    [typeof(ArrayPoolBench), typeof(MarshallApi), typeof(Pointers), typeof(StringWithSpan)],
    config
);
