using System.Collections;

namespace Akiles.ApiClient;

public class PagedList<T> : IEnumerable<T>
{
    public List<T> Data { get; set; } = [];
    public bool HasNext { get; set; }
    public string? CursorNext { get; set; }

    public void Add(T item) => Data.Add(item);

    public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
}
