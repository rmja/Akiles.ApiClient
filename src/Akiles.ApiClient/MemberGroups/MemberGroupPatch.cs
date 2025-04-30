using System.Text.Json.Serialization;

namespace Akiles.ApiClient.MemberGroups;

public record MemberGroupPatch
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<MemberGroupPermissionRulePatch>? Permissions { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Metadata { get; set; }
}
