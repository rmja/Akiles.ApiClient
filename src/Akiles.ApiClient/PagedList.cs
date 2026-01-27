using Cursor;

namespace Akiles.ApiClient;

public class PagedList<T> : ICursorPage<T>
{
    public List<T> Data { get; set; } = [];
    public bool HasNext { get; set; }
    public string? CursorNext { get; set; }

    List<T> ICursorPage<T>.Items => Data;

    string? ICursorPage<T>.NextCursor => CursorNext;

    public void Add(T item) => Data.Add(item);
}
