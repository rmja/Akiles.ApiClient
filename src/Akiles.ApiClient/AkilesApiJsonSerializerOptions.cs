using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using LanguageExt;

namespace Akiles.ApiClient;

public static class AkilesApiJsonSerializerOptions
{
    public static readonly JsonSerializerOptions Value =
        new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Converters =
            {
                new JsonStringEnumConverter(
                    JsonNamingPolicy.SnakeCaseLower,
                    allowIntegerValues: false
                ),
                new TimeOnlyJsonConverter(),
                new OptionJsonConverterFactory()
            },
            TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            {
                Modifiers = { ExcludeOptionNoneVariant }
            }
        };

    private static void ExcludeOptionNoneVariant(JsonTypeInfo typeInfo)
    {
        foreach (var property in typeInfo.Properties)
        {
            if (
                property.PropertyType.IsGenericType
                && property.PropertyType.GetGenericTypeDefinition() == typeof(Option<>)
            )
            {
                property.ShouldSerialize = static (_, value) =>
                    !value!.Equals(Activator.CreateInstance(value.GetType()));
            }
        }
    }
}

file class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var seconds = reader.GetInt32();
        return new TimeOnly(seconds * TimeSpan.TicksPerSecond);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        var seconds = value.Ticks / TimeSpan.TicksPerSecond;
        writer.WriteNumberValue(seconds);
    }
}

file class OptionJsonConverterFactory : JsonConverterFactory
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

file class OptionJsonConverter<T> : JsonConverter<Option<T>>
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
