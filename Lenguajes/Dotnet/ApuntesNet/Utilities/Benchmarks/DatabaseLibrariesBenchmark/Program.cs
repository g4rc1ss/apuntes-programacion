using BenchmarkDotNet.Running;
using DatabaseLibrariesBenchmark.Benchmarks;
using DatabaseLibrariesBenchmark.ConfigurationBenchmark;

BenchmarkRunner.Run<DatabaseFrameworksPerformance>(new Config());
