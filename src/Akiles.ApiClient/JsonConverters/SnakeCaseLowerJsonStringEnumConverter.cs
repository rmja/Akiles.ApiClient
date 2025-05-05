using System.Text.Json;
using System.Text.Json.Serialization;

namespace Akiles.ApiClient.JsonConverters;

internal class SnakeCaseLowerJsonStringEnumConverter<TEnum> : JsonStringEnumConverter<TEnum>
    where TEnum : struct, Enum
{
    public SnakeCaseLowerJsonStringEnumConverter()
        : base(JsonNamingPolicy.SnakeCaseLower, allowIntegerValues: false) { }
}
