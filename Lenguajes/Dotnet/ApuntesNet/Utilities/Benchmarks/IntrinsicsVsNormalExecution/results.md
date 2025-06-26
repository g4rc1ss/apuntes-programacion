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
