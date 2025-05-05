using System.Text.Json;
using System.Text.Json.Serialization;
using LanguageExt;

namespace Akiles.ApiClient.JsonConverters;

internal class OptionJsonConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert) =>
        typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Option<>);

    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var type = typeToConvert.GetGenericArguments()[0];
        var converterType = typeof(OptionJsonConverter<>).MakeGenericType(type);
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
}

internal class OptionJsonConverter<T> : JsonConverter<Option<T>>
{
    public override Option<T> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var value = JsonSerializer.Deserialize<T>(ref reader, options);
        return value;
    }

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
