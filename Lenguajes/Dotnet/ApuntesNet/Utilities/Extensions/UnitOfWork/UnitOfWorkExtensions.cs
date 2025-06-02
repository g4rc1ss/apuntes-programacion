namespace UnitOfWork;

/// <summary>
///
/// </summary>
public static class UnitOfWorkExtensions
{
    /// <summary>
    /// Obtiene una lista a partir de un IAsyncEnumerable de forma asincrona
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static async Task<List<T>> GetListAsync<T>(this IAsyncEnumerable<T> enumerable)
    {
        List<T>? buffer = [];
        await foreach (T? item in enumerable)
        {
            buffer.Add(item);
        }

        return buffer;
    }
}
