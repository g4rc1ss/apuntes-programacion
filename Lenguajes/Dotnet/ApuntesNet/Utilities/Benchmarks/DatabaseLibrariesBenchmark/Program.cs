using BenchmarkDotNet.Running;
using DatabaseLibrariesBenchmark.Benchmarks;
using DatabaseLibrariesBenchmark.ConfigurationBenchmark;

// await new EntityFrameworkBench().EntityFrameworkCoreSelectSingleQueryAsync();
// await new EntityFrameworkBench().EntityFrameworkCoreSelectSingleNoTrackingQueryAsync();
// await new EntityFrameworkBench().EntityFrameworkCoreSelectSingleCompiledQueryAsync();

// await new DapperBench().DapperSelectSingleQueryAsync();

BenchmarkRunner.Run([typeof(EntityFrameworkBench), typeof(DapperBench)], new Config());
