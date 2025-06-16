namespace Singleton;

public class PatronSingleton
{
    private static PatronSingleton? _singleton;

    public string? Nombre { get; set; }

    private PatronSingleton() { }

    public static PatronSingleton GetInstance()
    {
        _singleton ??= new PatronSingleton();

        return _singleton;
    }
}
