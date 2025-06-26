namespace PluginAPI.ExportAPI;

public class ExportInterface(object windowInterface, bool fullWindow)
{
    public readonly bool fullWindow = fullWindow;
    public readonly object windowInterface = windowInterface;
}
