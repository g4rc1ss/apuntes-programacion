| Method               |        Mean |     Error |    StdDev |   Gen0 | Allocated |
|----------------------|------------:|----------:|----------:|-------:|----------:|
| Record               |   0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| ModifyRecord         |   0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| CloneRecord          |   0.2399 ns | 0.0052 ns | 0.0049 ns |      - |         - |
| CreateRecordLoopList | 274.9643 ns | 1.1168 ns | 1.0447 ns | 0.4778 |    4000 B |
| ModifyRecordLoopList | 529.5974 ns | 4.7101 ns | 4.1753 ns | 0.9556 |    8000 B |
| CloneRecordLoopList  | 526.8556 ns | 2.1127 ns | 1.9762 ns | 0.9556 |    8000 B |
| Classes              |   0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| ModifyClass          |   0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| CloneClass           |   0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| CreateClassLoopList  | 266.6183 ns | 1.2931 ns | 1.2095 ns | 0.4778 |    4000 B |
| ModifyClassInLoop    | 272.0164 ns | 1.3549 ns | 1.2673 ns | 0.4778 |    4000 B |
| CloneClassInLoop     | 535.4567 ns | 2.0732 ns | 1.9393 ns | 0.9556 |    8000 B |