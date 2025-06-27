using AsyncOps.InteroperabilidadConAsync;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AsyncOps;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void CpuTaskAsync(object? sender, RoutedEventArgs e)
    {
        await Task.Run(() =>
        {
            Thread.Sleep(100000);
            Console.WriteLine("Codigo asincrono CPU terminado");
        });
    }

    private void CpuBlockAsync(object? sender, RoutedEventArgs e)
    {
        Thread.Sleep(100000);
    }

    private async void IoAsync(object? sender, RoutedEventArgs e)
    {
        HttpClient? cliente = new();
        await cliente.GetStringAsync("https://docs.microsoft.com/en-us/");
    }

    private async void EnumerableAsync(object? sender, RoutedEventArgs e)
    {
        await foreach (int item in RangeAsync(0, 1000)) { }

        async IAsyncEnumerable<int> RangeAsync(int start, int count)
        {
            for (; start < count; start++)
            {
                await Task.Delay(10);
                yield return start + 1;
            }
        }
    }

    private async void ExecuteCustomTaskAsync(object? sender, RoutedEventArgs e)
    {
        CustomTask customTask = new();
        await customTask;
    }

    private async void ExecuteWithPlatformInvokeAsync(object? sender, RoutedEventArgs e)
    {
        await new ClaseInteractuaRust().EjecutarDllAsync();
        await Task.Delay(100);
    }
}
