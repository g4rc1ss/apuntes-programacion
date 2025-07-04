using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;
using MicroBench;

// new MarshalApi().WriteStructMarshalWithSpan();

// new ArrayPoolBench().AddDataToStringMemoryPool();

ManualConfig config = ManualConfig
    .Create(DefaultConfig.Instance)
    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    .AddExporter(MarkdownExporter.Console);

BenchmarkRunner.Run(
    [
        // typeof(MarshalApi),
        // typeof(GCHandleApi),
        // typeof(ArrayPoolBench),
        // typeof(IntrinsicsApi),
        // typeof(Pointers),
        // typeof(StringWithSpan),
        typeof(CollectionsWithSpan),
    ],
    config
);
