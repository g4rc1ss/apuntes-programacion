| Method                   | iterations | Mean           | Error         | StdDev        | Median         | Gen0     | Gen1     | Gen2     | Allocated |
|------------------------- |----------- |---------------:|--------------:|--------------:|---------------:|---------:|---------:|---------:|----------:|
| AddDataToStringArrayPool | 1          |       5.031 ns |     0.0286 ns |     0.0254 ns |       5.035 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 1          |       3.029 ns |     0.0420 ns |     0.0372 ns |       3.034 ns |   0.0038 |        - |        - |      32 B |
| AddDataToStringArrayPool | 10         |      15.858 ns |     0.3210 ns |     0.2846 ns |      15.885 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 10         |      13.862 ns |     0.2948 ns |     0.4133 ns |      13.898 ns |   0.0124 |        - |        - |     104 B |
| AddDataToStringArrayPool | 100        |     118.714 ns |     1.7156 ns |     1.6048 ns |     119.034 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 100        |     110.942 ns |     0.4645 ns |     0.3879 ns |     110.973 ns |   0.0985 |        - |        - |     824 B |
| AddDataToStringArrayPool | 1000       |     938.163 ns |    18.1375 ns |    38.6525 ns |     917.655 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 1000       |   1,068.897 ns |    15.7689 ns |    12.3113 ns |   1,065.775 ns |   0.9575 |        - |        - |    8024 B |
| AddDataToStringArrayPool | 100000     |  92,548.954 ns | 1,793.1549 ns | 3,044.9134 ns |  91,284.953 ns |        - |        - |        - |         - |
| AddDataToStringArray     | 100000     | 160,166.169 ns | 3,169.3543 ns | 5,633.5246 ns | 160,495.992 ns | 249.7559 | 249.7559 | 249.7559 |  800192 B |
