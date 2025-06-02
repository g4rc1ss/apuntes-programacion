namespace Singleton;

public class PatronSingleton
{
    private static PatronSingleton? singleton;

    public string? Nombre { get; set; }

    private PatronSingleton() { }

    public static PatronSingleton GetInstance()
    {
        singleton ??= new PatronSingleton();

        return singleton;
    }
}
