using LanguageExt;

namespace Akiles.ApiClient.MemberGroups;

public record MemberGroupPermissionRulePatch
{
    public Option<string?> SiteId { get; set; }
    public Option<string?> GadgetId { get; set; }
    public Option<string?> ActionId { get; set; }
    public Option<string?> ScheduleId { get; set; }
    public Option<MemberGroupPermissionRulePresence> Presence { get; set; }
    public Option<MemberGroupPermissionRuleAccessMethodsPatch> AccessMethods { get; set; }
}
