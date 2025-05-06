using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Akiles.ApiClient.Schedules;

namespace Akiles.ApiClient.JsonConverters;

internal class WeekdayArrayJsonConverter<T> : JsonConverter<WeekdayArray<T>>
{
    [UnconditionalSuppressMessage(
        "ReflectionAnalysis",
        "IL2026:RequiresUnreferencedCode",
        Justification = "Inner value is referenced."
    )]
    public override WeekdayArray<T>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var storage = JsonSerializer.Deserialize<T[]>(ref reader, options)!;
        return new WeekdayArray<T>(storage);
    }

    [UnconditionalSuppressMessage(
        "ReflectionAnalysis",
        "IL2026:RequiresUnreferencedCode",
        Justification = "Inner value is referenced."
    )]
    public override void Write(
        Utf8JsonWriter writer,
        WeekdayArray<T> value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.GetArray(), options);
    }
}
