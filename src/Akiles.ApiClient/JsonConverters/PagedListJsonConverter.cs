using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Akiles.ApiClient.JsonConverters;

internal class PagedListJsonConverter<T> : JsonConverter<PagedList<T>>
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
    public override PagedList<T>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var page = new PagedList<T>();
        while (reader.Read() && reader.TokenType == JsonTokenType.PropertyName)
        {
            if (reader.ValueTextEquals("data"u8))
            {
                reader.Read();
                if (reader.TokenType == JsonTokenType.StartArray)
                {
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        var item = JsonSerializer.Deserialize<T>(ref reader, options)!;
                        page.Data.Add(item);
                    }
                }
            }
            else if (reader.ValueTextEquals("has_next"u8))
            {
                reader.Read();
                page.HasNext = reader.GetBoolean();
            }
            else if (reader.ValueTextEquals("cursor_next"))
            {
                reader.Read();
                page.CursorNext = reader.GetString();
            }
        }

        return page;
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
        PagedList<T> value,
        JsonSerializerOptions options
    )
    {
        writer.WriteStartObject();
        writer.WritePropertyName("data"u8);
        writer.WriteStartArray();
        foreach (var item in value.Data)
        {
            JsonSerializer.Serialize(writer, item, options);
        }
        writer.WriteEndArray();
        writer.WriteBoolean("has_next"u8, value.HasNext);
        if (value.CursorNext is not null)
        {
            writer.WriteString("cursor_next"u8, value.CursorNext);
        }
        writer.WriteEndObject();
    }
}
