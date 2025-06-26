using System.Diagnostics;
using Memorization.Clase;

Stopwatch? stopWatch = new();

stopWatch.Start();
Console.WriteLine(CalcularFibonacci(50));
stopWatch.Stop();
double tiempoFuncionNormal = stopWatch.Elapsed.TotalMilliseconds;

stopWatch.Reset();

stopWatch.Start();
Console.WriteLine(CalcularFibConMemoizacion(50));
stopWatch.Stop();
double tiempoFuncionMemoizacion = stopWatch.Elapsed.TotalMilliseconds;

Console.WriteLine(
    "-------------------------------------------------------------------------------"
);
Console.WriteLine(
    $"EL TIEMPO DE {nameof(CalcularFibonacci)} es: {tiempoFuncionNormal}\n"
        + $"EL TIEMPO DE {nameof(CalcularFibConMemoizacion)} es: {tiempoFuncionMemoizacion}"
);

long CalcularFibonacci(long numero)
{
    Console.WriteLine($"Calculando el fib de {numero}");
    return numero > 1 ? CalcularFibonacci(numero - 1) + CalcularFibonacci(numero - 2) : numero;
}

long CalcularFibConMemoizacion(long numero)
{
    Console.WriteLine($"Calculando el fib de {numero}");
    return numero > 1
        ? Memoizacion<long, long>.AddMemoizacion(CalcularFibConMemoizacion, numero - 1)
            + Memoizacion<long, long>.AddMemoizacion(CalcularFibConMemoizacion, numero - 2)
        : numero;
}
