using Refit;

namespace Akiles.ApiClient.Events;

public interface IEvents
{
    [Get("/events")]
    Task<PagedList<Event>> ListEventsAsync(
        string? cursor,
        int? limit,
        Sort<Event>? sort,
        ListEventsFilter? filter = null,
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

public record ListEventsFilter
{
    public EventVerb? Verb { get; set; }
    public ListEventsSubjectFilter? Subject { get; set; }
    public ListEventsObjectFilter? Object { get; set; }
}

public record ListEventsSubjectFilter
{
    public string? MemberId { get; set; }
    public string? MemberPinId { get; set; }
    public string? MemberCardId { get; set; }
    public string? MemberTokenId { get; set; }
}

public record ListEventsObjectFilter
{
    public EventObjectType? Type { get; set; }
    public string? DeviceId { get; set; }
    public string? GadgetId { get; set; }
    public string? GadgetActionId { get; set; }
    public string? MemberId { get; set; }
}
