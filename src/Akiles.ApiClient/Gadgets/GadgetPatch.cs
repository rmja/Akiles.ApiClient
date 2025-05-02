using System.Text.Json.Serialization;

namespace Akiles.ApiClient.Gadgets;

public record GadgetPatch
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string?>? Metadata { get; set; }
}
