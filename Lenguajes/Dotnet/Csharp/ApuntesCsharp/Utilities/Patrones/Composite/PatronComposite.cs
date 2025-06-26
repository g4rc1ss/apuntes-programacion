namespace Composite;

public class PatronComposite : ILogger
{
    // Contenemos un objeto que referencia a instancias del objeto original o clase base.
    private readonly Logging _loggingOriginal;

    public PatronComposite()
    {
        _loggingOriginal = new Logging();
    }

    public void LogInfo(string message)
    {
        _loggingOriginal.LogInfo(message);
    }

    public void LogError(string message, Exception e)
    {
        _loggingOriginal.LogError(message, e);
    }

    public void LogFatal(string message, Exception e)
    {
        Console.WriteLine($"Hemos guardado {message} en Base de datos");
    }
}
