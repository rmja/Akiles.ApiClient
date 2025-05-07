namespace Akiles.ApiClient.Events;

public record ListEventsObjectFilter
{
    public EventObjectType? Type { get; set; }
    public string? DeviceId { get; set; }
    public string? GadgetId { get; set; }
    public string? GadgetActionId { get; set; }
    public string? MemberId { get; set; }
}
