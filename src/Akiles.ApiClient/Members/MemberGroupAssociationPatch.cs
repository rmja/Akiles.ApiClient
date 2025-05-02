using System.Text.Json.Serialization;
using LanguageExt;

namespace Akiles.ApiClient.Members;

public record MemberGroupAssociationPatch
{
    public Option<DateTime?> StartsAt { get; set; }
    public Option<DateTime?> EndsAt { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string?>? Metadata { get; set; }
}
