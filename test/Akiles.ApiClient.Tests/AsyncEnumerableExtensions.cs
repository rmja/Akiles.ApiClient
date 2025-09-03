namespace Akiles.ApiClient.Tests;

internal static class AsyncEnumerableExtensions
{
    public static async IAsyncEnumerable<T> TakeAsync<T>(this IAsyncEnumerable<T> source, int count)
    {
        if (count == 0)
        {
            yield break;
        }

        await foreach (var item in source.ConfigureAwait(false))
        {
            yield return item;
            count--;
            if (count == 0)
            {
                yield break;
            }
        }
    }

    public static async Task<List<T>> ToListAsync<T>(
        this IAsyncEnumerable<T> source,
        CancellationToken cancellationToken = default
    )
    {
        var result = new List<T>();

        await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            cancellationToken.ThrowIfCancellationRequested();
            result.Add(item);
        }

        return result;
    }
}
