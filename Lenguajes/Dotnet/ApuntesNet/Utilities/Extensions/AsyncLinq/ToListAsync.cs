namespace AsyncLinq;

/// <summary>
///
/// </summary>
public static class ListAsync
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static async Task<List<T>> GetListAsync<T>(this IAsyncEnumerable<T> value)
    {
        List<T>? buffer = [];
        await foreach (T? item in value)
        {
            buffer.Add(item);
        }

        return buffer;
    }
}
