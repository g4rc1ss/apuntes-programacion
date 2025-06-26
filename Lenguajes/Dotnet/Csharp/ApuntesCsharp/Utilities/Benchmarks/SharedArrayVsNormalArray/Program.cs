using BenchmarkDotNet.Running;
using SharedArrayVsNormalArray;

BenchmarkRunner.Run([typeof(ArrayPoolBench)]);
