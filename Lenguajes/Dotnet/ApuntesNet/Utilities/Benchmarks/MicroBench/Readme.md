# ArrayPool

| Method                   | iterations | Mean           | Error         | StdDev        | Gen0     | Gen1     | Gen2     | Allocated |
|------------------------- |----------- |---------------:|--------------:|--------------:|---------:|---------:|---------:|----------:|
| AddDataToStringArrayPool | 1          |      15.031 ns |     0.0877 ns |     0.0820 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 1          |       6.673 ns |     0.0231 ns |     0.0204 ns |   0.0051 |        - |        - |      32 B |
| AddDataToStringArrayPool | 10         |      29.036 ns |     0.1350 ns |     0.1054 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 10         |      28.847 ns |     0.0878 ns |     0.0778 ns |   0.0166 |        - |        - |     104 B |
| AddDataToStringArrayPool | 100        |     218.158 ns |     0.1651 ns |     0.1463 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 100        |     250.981 ns |     0.6535 ns |     0.5457 ns |   0.1311 |        - |        - |     824 B |
| AddDataToStringArrayPool | 1000       |   2,071.958 ns |     8.2231 ns |     7.6919 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 1000       |   2,426.574 ns |    10.0506 ns |     9.4013 ns |   1.2779 |        - |        - |    8024 B |
| AddDataToStringArrayPool | 100000     | 204,913.728 ns |    82.0543 ns |    64.0626 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 100000     | 298,378.121 ns | 4,109.3402 ns | 3,843.8794 ns | 249.5117 | 249.5117 | 249.5117 |  800192 B |

# MarshallApi
| Method                       | Mean       | Error    | StdDev   | Gen0       | Gen1      | Gen2      | Allocated    |
|----------------------------- |-----------:|---------:|---------:|-----------:|----------:|----------:|-------------:|
| WriteIntWithMarshall         |   832.8 ms |  2.49 ms |  2.21 ms |          - |         - |         - |            - |
| WriteIntArrayWithManagement  | 2,070.1 ms | 28.32 ms | 25.11 ms |  9000.0000 | 9000.0000 | 9000.0000 | 8589941328 B |
| WriteObjectsWithMarshall     |   118.7 ms |  1.44 ms |  1.35 ms | 17400.0000 |         - |         - |  110399840 B |
| WriteArrayObjWithManagements |   207.9 ms |  2.35 ms |  2.20 ms | 19000.0000 | 7333.3333 | 1666.6667 |  118400995 B |


# Pointers
| Method                      | Mean     | Error   | StdDev  | Allocated |
|---------------------------- |---------:|--------:|--------:|----------:|
| ModifyArrayDataWithPointers | 422.3 ns | 1.63 ns | 1.52 ns |         - |
| ModifyArrayData             | 530.2 ns | 2.28 ns | 2.02 ns |         - |


# SubString
| Method                       | Mean       | Error     | StdDev    | Gen0   | Allocated |
|----------------------------- |-----------:|----------:|----------:|-------:|----------:|
| SubString                    |  4.5937 ns | 0.0144 ns | 0.0128 ns | 0.0051 |      32 B |
| SubstringSpan                |  0.6945 ns | 0.0010 ns | 0.0009 ns |      - |         - |
| SubstringSpanAndCreateString |  8.3082 ns | 0.0150 ns | 0.0133 ns | 0.0051 |      32 B |
| Split                        | 82.8366 ns | 0.2912 ns | 0.2724 ns | 0.0459 |     288 B |
| SplitSpan                    |  0.6955 ns | 0.0008 ns | 0.0007 ns |      - |         - |
| SplitSpanAndRead             | 28.1969 ns | 0.0116 ns | 0.0097 ns |      - |         - |
| StringContains               | 10.0554 ns | 0.0020 ns | 0.0018 ns |      - |         - |
| StringSpanContains           | 12.5352 ns | 0.0288 ns | 0.0270 ns |      - |         - |





