using System.Text.Json.Serialization;
using OneOf;
using OneOf.Types;

namespace Akiles.ApiClient.Members;

public record MemberGroupAssociationPatch
{
    public OneOf<None, DateTime?> StartsAt { get; set; }
    public OneOf<None, DateTime?> EndsAt { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string?>? Metadata { get; set; }
}
