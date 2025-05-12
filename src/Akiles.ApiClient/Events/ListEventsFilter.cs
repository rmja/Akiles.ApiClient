using Refit;

namespace Akiles.ApiClient.Events;

public record ListEventsFilter
{
    public EventVerb? Verb { get; set; }

    [AliasAs("subject.")]
    public ListEventsSubjectFilter? Subject { get; set; }

    [AliasAs("object.")]
    public ListEventsObjectFilter? Object { get; set; }
    public RangeFilter<DateTimeOffset>? CreatedAt { get; set; }
}
