using System.Diagnostics;

int iteracionesRecursivas = 0;
List<int> arrayOrdenado = [.. Enumerable.Range(0, 1000_000_000)];
int numero = 1000_000_000 - 1;
bool existeNumero = false;
Stopwatch stopwatch = new();

Console.WriteLine(
    "\n----------------------- BUSQUEDA NORMAL POR ITERACION -----------------------"
);
stopwatch.Start();
existeNumero = BusquedaTradicional(in arrayOrdenado, numero);
stopwatch.Stop();
Console.WriteLine(
    $"{existeNumero} \n" + $"El tiempo de busqueda es: {stopwatch.Elapsed.TotalMilliseconds}"
);

stopwatch.Reset();

Console.WriteLine("\n----------------------- BUSQUEDA BINARIA ITERADA -----------------------");
stopwatch.Start();
existeNumero = BuscarValorIteracion(in arrayOrdenado, numero);
stopwatch.Stop();
Console.WriteLine(
    $"{existeNumero} \n" + $"El tiempo de busqueda es: {stopwatch.Elapsed.TotalMilliseconds}"
);

stopwatch.Reset();

Console.WriteLine("\n----------------------- BUSQUEDA BINARIA RECURSIVA -----------------------");
stopwatch.Start();
existeNumero = BuscarValorRecurviso(in arrayOrdenado, numero, 0, arrayOrdenado.Count - 1);
stopwatch.Stop();
Console.WriteLine(
    $"{existeNumero} \n" + $"El tiempo de busqueda es: {stopwatch.Elapsed.TotalMilliseconds}"
);

bool BusquedaTradicional(in List<int> arrayOrdenado, long numero)
{
    int iteraciones = 0;
    foreach (int item in arrayOrdenado)
    {
        iteraciones++;
        if (item == numero)
        {
            Console.WriteLine($"El numero de iteraciones son: {iteraciones}");
            return true;
        }
    }
    Console.WriteLine($"El numero de iteraciones son: {iteraciones}");
    return false;
}

bool BuscarValorIteracion(in List<int> arrayOrdenado, long numero)
{
    int iteraciones = 0;
    int left = 0;
    int right = arrayOrdenado.Count - 1;

    while (left <= right)
    {
        iteraciones++;
        int mitad = (right + left) / 2;
        if (arrayOrdenado[mitad] == numero)
        {
            Console.WriteLine($"El numero de iteraciones son: {iteraciones}");
            return true;
        }
        else if (arrayOrdenado[mitad] < numero)
        {
            // Movemos el left a la derecha una posicion
            left = mitad + 1;
        }
        else if (arrayOrdenado[mitad] > numero)
        {
            // Movemos el right a la izquierda una posicion
            right = mitad - 1;
        }
    }
    Console.WriteLine($"El numero de iteraciones son: {iteraciones}");
    return false;
}

bool BuscarValorRecurviso(in List<int> arrayOrdenado, long numero, int left, int right)
{
    iteracionesRecursivas++;
    int mitad = (right + left) / 2;
    bool valorRetorno = false;
    if (right < left)
    {
        return false;
    }

    if (arrayOrdenado[mitad] == numero)
    {
        Console.WriteLine($"El numero de iteraciones son: {iteracionesRecursivas}");
        return true;
    }
    else if (arrayOrdenado[mitad] < numero)
    {
        valorRetorno = BuscarValorRecurviso(arrayOrdenado, numero, mitad + 1, right);
    }
    else if (arrayOrdenado[mitad] > numero)
    {
        valorRetorno = BuscarValorRecurviso(arrayOrdenado, numero, left, mitad - 1);
    }
    return valorRetorno;
}
