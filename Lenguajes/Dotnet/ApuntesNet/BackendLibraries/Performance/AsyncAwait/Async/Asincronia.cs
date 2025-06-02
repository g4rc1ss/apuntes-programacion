namespace AsyncAwait.Async;

public class Asincronia
{
    internal Task CpuAsync()
    {
        return Task.Run(() =>
        {
            Thread.Sleep(10000);
            Console.WriteLine("Codigo asincrono CPU terminado");
        });
    }

    internal async Task ESAsync()
    {
        HttpClient? cliente = new();
        await cliente.GetStringAsync("https://docs.microsoft.com/en-us/");
        Console.WriteLine("Codigo asincrono E/S terminado");
    }

    internal async Task ExecuteIEnumerableAsync()
    {
        await foreach (int item in RangeAsync(0, int.MaxValue)) { }
        Console.WriteLine("Codigo asincrono IAsyncEnumerable terminado");
    }

    private async IAsyncEnumerable<int> RangeAsync(int start, int count)
    {
        for (; start < count; start++)
        {
            await Task.Delay(10);
            yield return start + 1;
        }
    }
}
