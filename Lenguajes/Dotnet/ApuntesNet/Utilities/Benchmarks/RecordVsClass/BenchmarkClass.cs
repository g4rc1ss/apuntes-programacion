namespace RecordVsClass;

internal class BenchmarkClass
{
    public string? X { get; set; }
    public int Y { get; set; }
    public long Z { get; set; }
}

internal record BenchmarkRecord(string X, int Y, long Z);
