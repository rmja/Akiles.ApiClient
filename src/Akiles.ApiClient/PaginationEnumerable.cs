using System.Runtime.CompilerServices;

namespace Akiles.ApiClient;

internal class PaginationEnumerable<T>(Func<string?, CancellationToken, Task<PagedList<T>>> getPage)
    : IAsyncEnumerable<T>
{
    private async IAsyncEnumerable<T> EnumerateAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        var page = await getPage(null, cancellationToken);

        while (!cancellationToken.IsCancellationRequested)
        {
            foreach (var item in page.Data)
            {
                yield return item;
            }

            if (!page.HasNext)
            {
                break;
            }

            page = await getPage(page.CursorNext, cancellationToken);
        }
    }

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return EnumerateAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
