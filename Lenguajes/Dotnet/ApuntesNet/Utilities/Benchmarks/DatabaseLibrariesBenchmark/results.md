| Method                       | Mean         | StdDev     | Error       | Gen0    | Gen1    | Allocated |
|----------------------------- |-------------:|-----------:|------------:|--------:|--------:|----------:|
| 'Dapper single'              |     8.045 us |  0.0993 us |   0.1501 us |  0.3438 |       - |   2.12 KB |
| 'EF Core Single'             |    26.612 us |  0.9143 us |   1.5365 us |  2.0000 |  0.6250 |  12.55 KB |
| 'EF Core Single no Tracking' |    29.105 us |  1.1017 us |   1.8513 us |  2.0000 |  0.6250 |   12.4 KB |
| 'EF Core All'                |   358.512 us |  6.7112 us |  10.1463 us | 43.5000 |  2.5000 |  266.7 KB |
| 'Dapper Query'               | 1,064.262 us |  4.4261 us |   8.4627 us | 48.0000 | 10.0000 | 305.84 KB |
| 'EF Core All no Tracking'    | 1,175.172 us |  8.2223 us |  13.8170 us | 66.0000 | 16.0000 |  406.6 KB |
| 'EF Core Single Compilada'   | 1,960.797 us | 75.0324 us | 126.0871 us | 24.0000 | 12.0000 | 149.42 KB |
