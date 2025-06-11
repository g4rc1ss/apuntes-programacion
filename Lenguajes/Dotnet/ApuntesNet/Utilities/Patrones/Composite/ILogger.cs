namespace Composite;

public interface ILogger
{
    void LogInfo(string message);
    void LogError(string message, Exception e);
    void LogFatal(string message, Exception e);
}
