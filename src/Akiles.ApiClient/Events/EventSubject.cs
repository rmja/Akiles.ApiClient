namespace Akiles.ApiClient.Events;

public record EventSubject
{
    public string? MemberId { get; set; }
    public string? MemberEmailId { get; set; }
    public string? MemberMagicLinkId { get; set; }
    public string? MemberPinId { get; set; }
    public string? MemberCardId { get; set; }
    public string? MemberTokenId { get; set; }
}
