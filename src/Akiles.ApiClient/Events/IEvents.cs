using Refit;

namespace Akiles.ApiClient.Events;

public interface IEvents
{
    [Get("/events")]
    Task<PagedList<Event>> ListEventsAsync(
        string? cursor,
        int? limit,
        Sort<Event>? sort,
        [Query(delimiter: "")] ListEventsFilter? filter = null,
        EventsExpand expand = EventsExpand.None,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<Event> ListEventsAsync(
        Sort<Event>? sort = null,
        ListEventsFilter? filter = null,
        EventsExpand expand = EventsExpand.None
    ) =>
        new PaginationEnumerable<Event>(
            (cursor, cancellationToken) =>
                ListEventsAsync(
                    cursor,
                    Constants.DefaultPaginationLimit,
                    sort,
                    filter,
                    expand,
                    cancellationToken
                )
        );
}
