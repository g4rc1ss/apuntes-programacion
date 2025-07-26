using ConsoleApi;

// TODO: Console API Examples
await SimulateLoad(ProgressBar.ExecuteNormalProgressBarAsync);
await SimulateLoad(ProgressBar.ExecuteLoadingAsync);
await SimulateLoad(ProgressBar.ExecutePercentageLoadAsync);

ChangeColors.Execute();
SelectCoordinates.Execute();

static async Task SimulateLoad(Func<Coordinates, int, int, Task> action)
{
    int counting = 100;
    (int left, int top) = Console.GetCursorPosition();
    Coordinates coordinates = new() { left = left, top = top };

    for (int i = 0; i <= counting; i++)
    {
        await Task.Delay(10);
        await action(coordinates, i, counting);
    }

    Console.WriteLine();
}
