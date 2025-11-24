using System.Text.Json.Serialization;
using OneOf;
using OneOf.Types;

namespace Akiles.ApiClient.MemberGroups;

public record MemberGroupPermissionRulePatch
{
    public OneOf<None, string?> SiteId { get; set; }
    public OneOf<None, string?> GadgetId { get; set; }
    public OneOf<None, string?> ActionId { get; set; }
    public OneOf<None, string?> ScheduleId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MemberGroupPermissionRulePresence? Presence { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MemberGroupPermissionRuleAccessMethodsPatch? AccessMethods { get; set; }
}
