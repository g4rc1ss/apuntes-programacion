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

# Iterate enums
| Method          | iterations | Mean            | Error          | StdDev         | Allocated |
|---------------- |----------- |----------------:|---------------:|---------------:|----------:|
| NormalIteration | 1          |       0.6961 ns |      0.0010 ns |      0.0009 ns |         - |
| SpanIteration   | 1          |       0.6969 ns |      0.0011 ns |      0.0008 ns |         - |
| NormalIteration | 10         |      11.5359 ns |      0.0059 ns |      0.0053 ns |         - |
| SpanIteration   | 10         |      12.6309 ns |      0.0120 ns |      0.0112 ns |         - |
| NormalIteration | 100        |      72.1998 ns |      0.0433 ns |      0.0384 ns |         - |
| SpanIteration   | 100        |      47.5891 ns |      0.1185 ns |      0.0990 ns |         - |
| NormalIteration | 1000       |     671.8332 ns |      0.2448 ns |      0.2044 ns |         - |
| SpanIteration   | 1000       |     420.2478 ns |      0.2460 ns |      0.2055 ns |         - |
| NormalIteration | 100000     |  85,020.7882 ns |     38.6078 ns |     34.2249 ns |         - |
| SpanIteration   | 100000     |  58,511.7862 ns |    220.6042 ns |    195.5599 ns |         - |
| NormalIteration | 1000000    | 860,477.6285 ns | 16,333.8800 ns | 15,278.7215 ns |         - |
| SpanIteration   | 1000000    | 621,592.1416 ns | 11,879.3045 ns | 11,111.9088 ns |         - |


# Intrinsics
| Method                                        | iterations |           Mean |          Error |         StdDev |         Median |     Gen0 |     Gen1 |     Gen2 | Allocated |
|-----------------------------------------------|------------|---------------:|---------------:|---------------:|---------------:|---------:|---------:|---------:|----------:|
| SumArraysWithIntrinsicsAndFixed               | 1          |       2.979 ns |      0.0355 ns |      0.0297 ns |       2.987 ns |   0.0038 |        - |        - |      32 B |
| SumArraysWithIntrinsicsWithMarshal            | 1          |      38.746 ns |      0.7731 ns |      0.8272 ns |      38.436 ns |        - |        - |        - |         - |
| SumArraysWithIntrinsicsWithMarshalWithoutCopy | 1          |      13.590 ns |      0.1124 ns |      0.1051 ns |      13.586 ns |        - |        - |        - |         - |
| SumArrays                                     | 1          |       2.418 ns |      0.0534 ns |      0.0500 ns |       2.417 ns |   0.0038 |        - |        - |      32 B |
| SumArraysWithIntrinsicsAndFixed               | 10         |       4.200 ns |      0.0177 ns |      0.0166 ns |       4.195 ns |   0.0076 |        - |        - |      64 B |
| SumArraysWithIntrinsicsWithMarshal            | 10         |      45.126 ns |      0.3058 ns |      0.2860 ns |      45.060 ns |        - |        - |        - |         - |
| SumArraysWithIntrinsicsWithMarshalWithoutCopy | 10         |      15.595 ns |      0.0923 ns |      0.0863 ns |      15.605 ns |        - |        - |        - |         - |
| SumArrays                                     | 10         |       7.632 ns |      0.0236 ns |      0.0221 ns |       7.627 ns |   0.0076 |        - |        - |      64 B |
| SumArraysWithIntrinsicsAndFixed               | 100        |      16.861 ns |      0.1011 ns |      0.0946 ns |      16.904 ns |   0.0507 |        - |        - |     424 B |
| SumArraysWithIntrinsicsWithMarshal            | 100        |     119.878 ns |      2.2220 ns |      2.0784 ns |     120.726 ns |        - |        - |        - |         - |
| SumArraysWithIntrinsicsWithMarshalWithoutCopy | 100        |      41.721 ns |      0.4192 ns |      0.3922 ns |      41.656 ns |        - |        - |        - |         - |
| SumArrays                                     | 100        |      69.336 ns |      0.2744 ns |      0.2567 ns |      69.336 ns |   0.0507 |        - |        - |     424 B |
| SumArraysWithIntrinsicsAndFixed               | 1000       |     154.905 ns |      0.5822 ns |      0.5161 ns |     154.881 ns |   0.4809 |        - |        - |    4024 B |
| SumArraysWithIntrinsicsWithMarshal            | 1000       |     213.246 ns |      4.1184 ns |      4.0448 ns |     211.390 ns |        - |        - |        - |         - |
| SumArraysWithIntrinsicsWithMarshalWithoutCopy | 1000       |      87.525 ns |      0.3187 ns |      0.2661 ns |      87.515 ns |        - |        - |        - |         - |
| SumArrays                                     | 1000       |     675.092 ns |      1.5562 ns |      1.3795 ns |     675.167 ns |   0.4807 |        - |        - |    4024 B |
| SumArraysWithIntrinsicsAndFixed               | 100000     |  32,543.720 ns |    637.2231 ns |    596.0589 ns |  32,736.165 ns | 124.9390 | 124.9390 | 124.9390 |  400108 B |
| SumArraysWithIntrinsicsWithMarshal            | 100000     |  22,906.556 ns |    456.7275 ns |  1,058.5356 ns |  22,366.740 ns |        - |        - |        - |         - |
| SumArraysWithIntrinsicsWithMarshalWithoutCopy | 100000     |   9,877.711 ns |     33.4501 ns |     31.2892 ns |   9,868.811 ns |        - |        - |        - |         - |
| SumArrays                                     | 100000     |  82,426.227 ns |    448.5995 ns |    419.6202 ns |  82,535.405 ns | 124.8779 | 124.8779 | 124.8779 |  400108 B |
| SumArraysWithIntrinsicsAndFixed               | 1000000    | 335,996.000 ns |  5,487.5152 ns |  5,133.0251 ns | 336,206.807 ns | 153.3203 | 153.3203 | 153.3203 | 4000126 B |
| SumArraysWithIntrinsicsWithMarshal            | 1000000    | 619,530.377 ns | 12,022.2761 ns | 11,807.4827 ns | 621,199.218 ns |        - |        - |        - |       1 B |
| SumArraysWithIntrinsicsWithMarshalWithoutCopy | 1000000    | 351,480.364 ns | 24,056.2770 ns | 70,930.4805 ns | 385,970.378 ns |        - |        - |        - |         - |
| SumArrays                                     | 1000000    | 942,676.837 ns |  3,146.6060 ns |  2,943.3372 ns | 942,617.758 ns | 154.2969 | 154.2969 | 154.2969 | 4000127 B |


# GCHandle

| Method                 | iterations | Mean          | Error       | StdDev      | Gen0   | Allocated |
|----------------------- |----------- |--------------:|------------:|------------:|-------:|----------:|
| IterateObjArray        | 1          |      5.560 ns |   0.0745 ns |   0.0660 ns | 0.0051 |      32 B |
| IterateObjWithGCHandle | 1          |     28.495 ns |   0.1438 ns |   0.1345 ns | 0.0051 |      32 B |
| IterateObjArray        | 10         |     15.775 ns |   0.1550 ns |   0.1450 ns | 0.0102 |      64 B |
| IterateObjWithGCHandle | 10         |     35.504 ns |   0.6204 ns |   0.6371 ns | 0.0102 |      64 B |
| IterateObjArray        | 100        |    105.929 ns |   0.7281 ns |   0.6080 ns | 0.0675 |     424 B |
| IterateObjWithGCHandle | 100        |    135.679 ns |   1.6087 ns |   1.4261 ns | 0.0675 |     424 B |
| IterateObjArray        | 1000       |  1,065.052 ns |  10.7301 ns |   8.3773 ns | 0.6409 |    4024 B |
| IterateObjWithGCHandle | 1000       |  1,176.197 ns |  20.3087 ns |  18.0032 ns | 0.6409 |    4024 B |
| IterateObjArray        | 10000      |  9,719.177 ns | 124.3403 ns | 116.3080 ns | 6.3171 |   40024 B |
| IterateObjWithGCHandle | 10000      | 11,494.018 ns | 148.0806 ns | 131.2696 ns | 6.3171 |   40024 B |

