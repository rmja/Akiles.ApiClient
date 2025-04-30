using System.Text.Json.Serialization;
using LanguageExt;

namespace Akiles.ApiClient.Members;

public record MemberPatch
{
    public Option<string> Name { get; set; }
    public Option<DateTime?> StartsAt { get; set; }
    public Option<DateTime?> EndsAt { get; set; }
    public Option<bool> IsDeleted { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Metadata { get; set; }
}
