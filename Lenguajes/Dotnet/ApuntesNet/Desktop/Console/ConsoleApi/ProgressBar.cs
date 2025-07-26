namespace ConsoleApi;

public static class ProgressBar
{
    internal static Task ExecuteNormalProgressBarAsync(
        Coordinates coordinates,
        int actual,
        int total
    )
    {
        Console.SetCursorPosition(coordinates.left, coordinates.top);
        string bar = new('=', actual);
        Console.Write($"[{bar}{new string(' ', total - actual)}]");
        return Task.CompletedTask;
    }

    public static Task ExecuteLoadingAsync(Coordinates coordinates, int actual, int total)
    {
        char symbol = actual % 2 == 0 ? '|' : '-';
        Console.SetCursorPosition(coordinates.left, coordinates.top);
        Console.Write(symbol);
        return Task.CompletedTask;
    }

    public static Task ExecutePercentageLoadAsync(Coordinates coordinates, int actual, int total)
    {
        Console.SetCursorPosition(coordinates.left, coordinates.top);
        Console.Write($"{actual * 100 / total}%");
        return Task.CompletedTask;
    }
}

public struct Coordinates
{
    public int left;
    public int top;
}
