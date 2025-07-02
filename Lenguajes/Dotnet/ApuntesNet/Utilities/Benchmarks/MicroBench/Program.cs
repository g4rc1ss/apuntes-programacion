using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;
using MicroBench;

ManualConfig config = ManualConfig
    .Create(DefaultConfig.Instance)
    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    .AddExporter(MarkdownExporter.Console);

BenchmarkRunner.Run(
    [
        typeof(GCHandleApi),
        // typeof(ArrayPoolBench),
        // typeof(IntrinsicsApi),
        // typeof(Pointers),
        // typeof(StringWithSpan),
        // typeof(CollectionsWithSpan),
    ],
    config
);
