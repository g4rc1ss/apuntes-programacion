| Method                          |     Mean |   Error |  StdDev | Allocated |
|---------------------------------|---------:|--------:|--------:|----------:|
| ExecuteWithParallelAsync        | 110.4 ms | 0.73 ms | 0.68 ms |      4 KB |
| ExecuteWithTaskAsync            | 110.4 ms | 0.75 ms | 0.63 ms |      2 KB |
| ExecuteAsyncWithAwaitSecuential | 552.7 ms | 3.77 ms | 3.34 ms |      6 KB |
| ExecuteWithAsyncBlocking        | 555.5 ms | 7.26 ms | 6.44 ms |      7 KB |