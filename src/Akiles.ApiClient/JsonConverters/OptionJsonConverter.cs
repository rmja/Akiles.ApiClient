using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using OneOf.Types;

namespace Akiles.ApiClient.JsonConverters;

internal class OptionJsonConverter<T> : JsonConverter<OneOf<None, T?>>
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
    public override OneOf<None, T?> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<T>(ref reader, options);
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
        OneOf<None, T?> value,
        JsonSerializerOptions options
    )
    {
        if (value.TryPickT1(out var some, out _))
        {
            JsonSerializer.Serialize(writer, some, options);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
