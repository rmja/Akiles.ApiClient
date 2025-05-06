using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LanguageExt;

namespace Akiles.ApiClient.JsonConverters;

internal class OptionJsonConverter<T> : JsonConverter<Option<T>>
{
    [UnconditionalSuppressMessage(
        "ReflectionAnalysis",
        "IL2026:RequiresUnreferencedCode",
        Justification = "Inner value is referenced."
    )]
    [UnconditionalSuppressMessage(
        "AOT",
        "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.",
        Justification = "Inner value is referenced."
    )]
    public override Option<T> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var value = JsonSerializer.Deserialize<T>(ref reader, options);
        return value;
    }

    [UnconditionalSuppressMessage(
        "ReflectionAnalysis",
        "IL2026:RequiresUnreferencedCode",
        Justification = "Inner value is referenced."
    )]
    [UnconditionalSuppressMessage(
        "AOT",
        "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.",
        Justification = "Inner value is referenced."
    )]
    public override void Write(
        Utf8JsonWriter writer,
        Option<T> value,
        JsonSerializerOptions options
    )
    {
        var innerValue = (T)value;
        JsonSerializer.Serialize(writer, innerValue, options);
    }
}
