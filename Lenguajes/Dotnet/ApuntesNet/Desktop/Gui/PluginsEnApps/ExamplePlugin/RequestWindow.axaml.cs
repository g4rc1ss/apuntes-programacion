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

    private async void Button_Clicked(System.Object sender, RoutedEventArgs e)
    {
        string? response = await GetMyIp();
        ExportAPI.ExportEventCaller(new ExportObject(response));
    }

    private async Task<string> GetMyIp()
    {
        try
        {
            MyIp? ip = await new HttpClient().GetFromJsonAsync<MyIp>(
                "https://api.ipify.org/?format=json"
            );
            return $"Direccion ip: {ip.Ip} \n";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
