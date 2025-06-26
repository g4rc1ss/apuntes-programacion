| Method                       |     Mean |    StdDev |     Error |   Gen 0 |  Gen 1 | Allocated |
|------------------------------|---------:|----------:|----------:|--------:|-------:|----------:|
| 'Dapper single'              | 1.370 ms | 0.0240 ms | 0.0363 ms |       - |      - |      5 KB |
| 'EF Core Single'             | 1.565 ms | 0.0356 ms | 0.0538 ms |  4.0000 |      - |     22 KB |
| 'EF Core Single no Tranking' | 1.604 ms | 0.0637 ms | 0.0962 ms |  2.0000 |      - |     11 KB |
| 'EF Core Single Compilada'   | 4.384 ms | 0.2247 ms | 0.3396 ms | 22.0000 | 2.0000 |     96 KB |