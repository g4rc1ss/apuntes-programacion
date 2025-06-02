using System.Reflection;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using PluginAPI;
using PluginAPI.ExportAPI;

namespace ExtendedApp;

public partial class MainWindow : Window
{
    private readonly List<DllData> _dllData = [];

    public MainWindow()
    {
        InitializeComponent();
        LoadEventCallers();
    }

    private async void CargarPluginsCLick(System.Object sender, RoutedEventArgs e)
    {
        IReadOnlyList<IStorageFile>? openFileDialog1 = await StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions()
        );
        string? fullPath = openFileDialog1?.FirstOrDefault()?.Path.LocalPath;
        string? name = openFileDialog1?.FirstOrDefault()?.Name;
        if (!string.IsNullOrEmpty(fullPath))
        {
            IPlugin? plugin = CreateInstanceForAssemblyPath(fullPath);
            DllData? pluginData = new() { Name = name, Path = fullPath };

            _dllData.Add(pluginData);
            ListaPlugins.ItemsView.Source.Add(pluginData);
        }
    }

    private void ListaPlugins_SelectionChanged(System.Object sender, SelectionChangedEventArgs e)
    {
        if (ListaPlugins.SelectedItem != null && ListaPlugins.SelectedItem is DllData pluginData)
        {
            if (!string.IsNullOrEmpty(pluginData?.Path))
            {
                IPlugin? plugin = CreateInstanceForAssemblyPath(pluginData.Path);
                plugin.Execute();

                if (plugin.ExportInterface.fullWindow)
                {
                    if (plugin.ExportInterface.windowInterface is Window exportInterface)
                    {
                        exportInterface.Show();
                    }
                }
                else
                {
                    Control.Content = plugin.ExportInterface.windowInterface;
                }
            }
        }
    }

    private IPlugin CreateInstanceForAssemblyPath(string path)
    {
        Assembly? plugin = Assembly.LoadFrom(path);
        Type? pluginType = (
            from tipo in plugin.GetTypes()
            where tipo.GetInterface(nameof(IPlugin)) != null
            select tipo
        ).FirstOrDefault();

        return Activator.CreateInstance(pluginType) as IPlugin;
    }

    private void LoadEventCallers()
    {
        ExportAPI.ExportEvent += LoadEventCall;
    }

    private void LoadEventCall(object sender, EventArgs e)
    {
        ExportObject? itemToLoad = sender as ExportObject;
        if (itemToLoad?.ObjectToExport is string export)
        {
            // await DisplayAlert("Plugin", export, "Cancel");
        }
    }
}
