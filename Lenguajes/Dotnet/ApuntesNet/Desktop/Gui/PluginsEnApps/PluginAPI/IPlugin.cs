using PluginAPI.ExportAPI;

namespace PluginAPI;

public interface IPlugin
{
    ExportInterface ExportInterface { get; }
    ExportPlugin ExportPlugin { get; }
    string Name { get; }

    string Description { get; }

    void Execute();
}
