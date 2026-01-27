using Akiles.ApiClient.Events;
using Cursor;
using Refit;

namespace Akiles.ApiClient;

public interface IEvents
{
    [Get("/events")]
    [GenerateEnumerator]
    Task<PagedList<Event>> ListEventsAsync(
        Sort<Event>? sort = null,
        [Query(delimiter: "")] ListEventsFilter? filter = null,
        EventsExpand expand = EventsExpand.None,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );
}
