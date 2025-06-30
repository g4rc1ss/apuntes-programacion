using System.Net.Http.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PluginAPI.ExportAPI;

namespace ExamplePlugin;

public partial class RequestWindow : Window
{
    public RequestWindow()
    {
        InitializeComponent();
    }

    private async void Button_ClickedAsync(object sender, RoutedEventArgs e)
    {
        string? response = await GetMyIpAsync();
        ExportApi.ExportEventCaller(new ExportObject(response));
    }

    private async Task<string> GetMyIpAsync()
    {
        try
        {
            using HttpClient client = new();
            MyIp? ip = await client.GetFromJsonAsync<MyIp>("https://api.ipify.org/?format=json");
            return $"Direccion ip: {ip.Ip} \n";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
