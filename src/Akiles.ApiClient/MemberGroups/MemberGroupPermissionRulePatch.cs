using System.Text.Json.Serialization;
using LanguageExt;

namespace Akiles.ApiClient.MemberGroups;

public record MemberGroupPermissionRulePatch
{
    public Option<string?> SiteId { get; set; }
    public Option<string?> GadgetId { get; set; }
    public Option<string?> ActionId { get; set; }
    public Option<string?> ScheduleId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MemberGroupPermissionRulePresence? Presence { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MemberGroupPermissionRuleAccessMethodsPatch? AccessMethods { get; set; }
}
