using System.Text.Json;
using System.Text.Json.Serialization;
using Akiles.ApiClient.Schedules;

namespace Akiles.ApiClient.JsonConverters;

internal class WeekdayArrayJsonConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert) =>
        typeToConvert.IsGenericType
        && typeToConvert.GetGenericTypeDefinition() == typeof(WeekdayArray<>);

    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var itemType = typeToConvert.GetGenericArguments()[0];
        var converterType = typeof(WeekdayArrayJsonConverter<>).MakeGenericType(itemType);
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
}

internal class WeekdayArrayJsonConverter<T> : JsonConverter<WeekdayArray<T>>
{
    public override WeekdayArray<T>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var storage = JsonSerializer.Deserialize<T[]>(ref reader, options)!;
        return new WeekdayArray<T>(storage);
    }

    public override void Write(
        Utf8JsonWriter writer,
        WeekdayArray<T> value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.GetArray(), options);
    }
}
