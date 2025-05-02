using System.Text.Json.Serialization;

namespace Akiles.ApiClient.Cards;

public record CardPatch
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string?>? Metadata { get; set; }
}
