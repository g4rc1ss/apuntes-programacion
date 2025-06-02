using BenchmarkDotNet.Running;
using UnmanagedMemoryVsNormalBenchmark;

Type[]? runs = [typeof(MarshallApi), typeof(Pointers), typeof(StackallocMemory)];
BenchmarkRunner.Run(runs);
