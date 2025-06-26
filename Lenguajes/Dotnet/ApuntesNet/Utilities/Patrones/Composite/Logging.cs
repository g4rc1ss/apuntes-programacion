namespace Composite;

public class Logging : ILogger
{
    public void LogInfo(string message)
    {
        Console.WriteLine($"Info - {message}");
    }

    public void LogError(string message, Exception e)
    {
        Console.WriteLine($"Error - {message} - Excepcion {e?.Message}");
    }

    public void LogFatal(string message, Exception e)
    {
        Console.WriteLine($"Fatal - {message} - Excepcion {e?.Message}");
    }
}
