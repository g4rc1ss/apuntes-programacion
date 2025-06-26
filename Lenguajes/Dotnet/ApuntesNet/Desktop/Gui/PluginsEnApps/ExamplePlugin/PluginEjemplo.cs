using PluginAPI;
using PluginAPI.ExportAPI;

namespace ExamplePlugin;

public class PluginEjemplo : IPlugin
{
    public ExportInterface? ExportInterface { get; private set; }

    public ExportPlugin? ExportPlugin { get; private set; }

    public string Name => "Plugin ejemplo";

    public string Description => "Plugin de ejemplo en .Net MAUI";

    public void Execute()
    {
        ExportInterface = new ExportInterface(new RequestWindow().Content!, false);
    }
}
