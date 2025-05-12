namespace Akiles.ApiClient.Events;

public record ListEventsFilter
{
    public EventVerb? Verb { get; set; }
    public ListEventsSubjectFilter? Subject { get; set; }
    public ListEventsObjectFilter? Object { get; set; }
    public RangeFilter<DateTimeOffset>? CreatedAt { get; set; }
}
