namespace Paging.Internal;

internal class Paginate<T> : IPaginate<T>
    where T : class
{
    public int From { get; set; }
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }
    public bool HasPrevious => Index - From > 0;
    public bool HasNext => Index - From + 1 < Pages;

    internal Paginate()
    {
        Items = [];
    }
}
