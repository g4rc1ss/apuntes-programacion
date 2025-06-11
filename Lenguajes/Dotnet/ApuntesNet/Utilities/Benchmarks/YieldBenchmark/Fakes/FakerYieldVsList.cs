namespace YieldBenchmark.Fakes;

public class FakerYieldVsList
{
    private const int NUMBEROFOBJECTS = 1000_000_000;

    public static List<int> WithBuffer()
    {
        List<int>? buffer = [.. Enumerable.Range(0, NUMBEROFOBJECTS)];
        return buffer;
    }

    public static IEnumerable<int> WithYield()
    {
        foreach (int item in Enumerable.Range(0, NUMBEROFOBJECTS))
        {
            yield return item;
        }
    }
}
