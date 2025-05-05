using System.Text.Json;
using System.Text.Json.Serialization;

namespace Akiles.ApiClient.JsonConverters;

internal class PagedListJsonConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert) =>
        typeToConvert.IsGenericType
        && typeToConvert.GetGenericTypeDefinition() == typeof(PagedList<>);

    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var dataType = typeToConvert.GetGenericArguments()[0];
        var converterType = typeof(PagedListJsonConverter<>).MakeGenericType(dataType);
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
}

internal class PagedListJsonConverter<T> : JsonConverter<PagedList<T>>
{
    public override PagedList<T>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var model = JsonSerializer.Deserialize<Model>(ref reader, options);
        if (model is null)
        {
            return null;
        }
        return new PagedList<T>()
        {
            Data = model.Data,
            HasNext = model.HasNext,
            CursorNext = model.CursorNext
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PagedList<T> value,
        JsonSerializerOptions options
    )
    {
        var model = new Model
        {
            Data = value.Data,
            HasNext = value.HasNext,
            CursorNext = value.CursorNext
        };
        JsonSerializer.Serialize(writer, model, options);
    }

    private class Model
    {
        public required List<T> Data { get; set; }
        public bool HasNext { get; set; }
        public string? CursorNext { get; set; }
    }
}
