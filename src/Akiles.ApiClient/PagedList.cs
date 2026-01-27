using System.Runtime.CompilerServices;
using Cursor;

namespace Akiles.ApiClient;

[CollectionBuilder(typeof(PagedListBuilder), nameof(PagedListBuilder.Create))]
public class PagedList<T> : ICursorPage<T>
{
    public List<T> Data { get; set; } = [];
    public bool HasNext { get; set; }
    public string? CursorNext { get; set; }

    List<T> ICursorPage<T>.Items => Data;

    string? ICursorPage<T>.NextCursor => CursorNext;

    public List<T>.Enumerator GetEnumerator() => Data.GetEnumerator();
}

public static class PagedListBuilder
{
    public static PagedList<T> Create<T>(ReadOnlySpan<T> items)
    {
        var page = new PagedList<T>();
        page.Data.EnsureCapacity(items.Length);
        foreach (var item in items)
        {
            page.Data.Add(item);
        }
        return page;
    }
}
