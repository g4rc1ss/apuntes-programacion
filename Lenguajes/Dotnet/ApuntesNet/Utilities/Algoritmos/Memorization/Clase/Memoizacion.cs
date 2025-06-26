namespace Memorization.Clase;

internal class Memoizacion<T, TResult>
{
    private static readonly Dictionary<T, TResult> _diccionario = [];

    public static TResult AddMemoizacion(Func<T, TResult> method, T argument)
    {
        if (!_diccionario.TryGetValue(argument, out TResult? result))
        {
            result = method.Invoke(argument);
            _diccionario.Add(argument, result);
        }
        return result;
    }
}
