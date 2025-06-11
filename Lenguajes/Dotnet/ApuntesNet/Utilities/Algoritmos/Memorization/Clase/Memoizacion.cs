namespace Memorization.Clase;

internal class Memoizacion<T, TResult>
{
    private static readonly Dictionary<T, TResult> Diccionario = [];

    public static TResult AddMemoizacion(Func<T, TResult> method, T argument)
    {
        if (!Diccionario.TryGetValue(argument, out TResult? result))
        {
            result = method.Invoke(argument);
            Diccionario.Add(argument, result);
        }
        return result;
    }
}
