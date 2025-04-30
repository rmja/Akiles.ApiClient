using System.Runtime.CompilerServices;

namespace Akiles.ApiClient.Tests;

internal static class AsyncEnumerableExtensions
{
    public static async IAsyncEnumerable<T> TakeAsync<T>(
        this IAsyncEnumerable<T> source,
        int count,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        if (count == 0)
        {
            yield break;
        }

        await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            cancellationToken.ThrowIfCancellationRequested();
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
