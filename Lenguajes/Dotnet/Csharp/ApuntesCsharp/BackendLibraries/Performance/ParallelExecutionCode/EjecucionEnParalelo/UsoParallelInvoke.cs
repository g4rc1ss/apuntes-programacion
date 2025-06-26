namespace ParallelExecutionCode.EjecucionEnParalelo;

internal class UsoParallelInvoke
{
    public UsoParallelInvoke()
    {
        Parallel.Invoke(() => Console.WriteLine("Hola 1"), () => Metodo2(2));
    }

    private static void Metodo2(int numero)
    {
        Console.WriteLine($"Hola {numero}");
    }
}
