namespace PluginAPI.ExportAPI;

public sealed class ExportObject(object objectToExport)
{
    public object ObjectToExport { get; } = objectToExport;
}
