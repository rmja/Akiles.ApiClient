using System.Text.Json.Serialization;

namespace Akiles.ApiClient.Cards;

public record CardPatch
{
    public string? Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string?>? Metadata { get; set; }
}
