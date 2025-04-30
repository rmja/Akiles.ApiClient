namespace Akiles.ApiClient.MemberGroups;

public record MemberGroupPermissionRule
{
    public string? SiteId { get; set; }
    public string? GadgetId { get; set; }
    public string? ActionId { get; set; }
    public string? ScheduleId { get; set; }
    public MemberGroupPermissionRulePresence Presence { get; set; }
    public MemberGroupPermissionRuleAccessMethods? AccessMethods { get; set; }
}
