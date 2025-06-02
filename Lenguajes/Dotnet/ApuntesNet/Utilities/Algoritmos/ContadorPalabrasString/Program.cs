using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

Stopwatch? stopWatch = new();
string? stringToCount = GenerarStringToCount();

string[]? cadenaArray = CleanAndConvertString(stringToCount);

stopWatch.Start();
long totalIteracionDiccionario = ContadorPalabras(cadenaArray);
stopWatch.Stop();

Console.WriteLine(
    $"La instruccion con Diccionario tarda: {stopWatch.Elapsed.TotalMilliseconds}\n"
        + $"Se han realizado {totalIteracionDiccionario} iteraciones."
);

stopWatch.Reset();

stopWatch.Start();
long totalIteracionesCuadratico = ContadorTradicionalPalabras(cadenaArray);
stopWatch.Stop();
Console.WriteLine(
    $"La instruccion con doble iteracion tarda: {stopWatch.Elapsed.TotalMilliseconds}\n"
        + $"Se han realizado {totalIteracionesCuadratico} iteraciones."
);

Console.WriteLine("Pulsa una tecla para finalizar...");
Console.ReadKey();

long ContadorTradicionalPalabras(string[] cadenaArray)
{
    long iteraciones = 0;
    List<string>? palabrasEvaluadas = [];
    for (int i = 0; i < cadenaArray.Length; i++)
    {
        if (!palabrasEvaluadas.Contains(cadenaArray[i]))
        {
            int repeticionPalabra = 0;
            for (int x = i; x < cadenaArray.Length; x++)
            {
                if (cadenaArray[i] == cadenaArray[x])
                {
                    repeticionPalabra++;
                }
                iteraciones++;
            }
            palabrasEvaluadas.Add(cadenaArray[i]);
            //Console.WriteLine($"La palabra: {cadenaArray[i]} \n" +
            //    $"repeticiones: {repeticionPalabra}\n" +
            //    $"-----------------------------------------------------------------");
        }
        iteraciones++;
    }
    return iteraciones;
}

long ContadorPalabras(string[] cadenaArray)
{
    Dictionary<string, int>? diccionarioPalabras = [];
    long iteraciones = 0;

    for (int i = 0; i < cadenaArray.Length; i++)
    {
        if (!diccionarioPalabras.ContainsKey(cadenaArray[i]))
        {
            diccionarioPalabras.Add(cadenaArray[i], 0);
        }
        diccionarioPalabras[cadenaArray[i]]++;
        iteraciones++;
    }
    //PrintDictionary(diccionarioPalabras);
    return iteraciones;
}

void PrintDictionary(Dictionary<string, int> diccionario)
{
    foreach (KeyValuePair<string, int> item in diccionario)
    {
        Console.WriteLine(
            $"La palabra: {item.Key} \n"
                + $"repeticiones: {item.Value}\n"
                + $"-----------------------------------------------------------------"
        );
    }
}

string GenerarStringToCount()
{
    string? cadena =
        "Hola, este es un mensaje para hacer la prueba de contador de palabras.\n"
        + "lo suyo es usar palabras que se repitan un poco para ver como funciona el metodo que vamos a realizar.";
    StringBuilder? cadenaToReturn = new();
    foreach (int item in Enumerable.Range(0, 100_000))
    {
        cadenaToReturn.Append(cadena);
    }
    return cadenaToReturn.ToString();
}

string[] CleanAndConvertString(string stringToCount)
{
    string? replace = Regex.Replace(stringToCount, @"[,.]*", string.Empty);
    return Regex.Split(replace, @"\W");
}
