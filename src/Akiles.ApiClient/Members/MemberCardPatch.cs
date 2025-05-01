using System.Text.Json.Serialization;

namespace Akiles.ApiClient.Members;

public record MemberCardPatch
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Metadata { get; set; }
}
