using BenchmarkDotNet.Running;
using ParallelBenchmark.Benchmarks;

BenchmarkRunner.Run<ThreadsVsAsync>();
