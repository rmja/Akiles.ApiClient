namespace Akiles.ApiClient.Events;

public record ListEventsSubjectFilter
{
    public string? MemberId { get; set; }
    public string? MemberPinId { get; set; }
    public string? MemberCardId { get; set; }
    public string? MemberTokenId { get; set; }
}
