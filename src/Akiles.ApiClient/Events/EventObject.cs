namespace Akiles.ApiClient.Events;

public record EventObject
{
    public EventObjectType Type { get; set; }
    public string? DeviceId { get; set; }
    public string? GadgetId { get; set; }
    public string? GadgetActionId { get; set; }
    public string? GadgetSignalId { get; set; }
    public string? MemberId { get; set; }
    public string? MemberEmailId { get; set; }
    public string? MemberMagicLinkId { get; set; }
    public string? MemberGroupId { get; set; }
    public string? MemberGroupAssociationId { get; set; }
    public string? MemberPinId { get; set; }
    public string? MemberCardId { get; set; }
    public string? MemberTokenId { get; set; }
    public string? OrganizationId { get; set; }
    public string? SiteId { get; set; }
    public string? WebhookId { get; set; }
    public string? HardwareId { get; set; }
    public string? CardId { get; set; }
}
