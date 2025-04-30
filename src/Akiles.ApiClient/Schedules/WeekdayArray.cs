using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Akiles.ApiClient.Schedules;

[JsonConverter(typeof(WeekdayArrayJsonConverter))]
public class WeekdayArray<T> : IReadOnlyList<T>
{
    private readonly T[] _storage;

    public T this[DayOfWeek weekday]
    {
        get => this[GetIndex(weekday)];
        set => this[GetIndex(weekday)] = value;
    }

    public T this[int index]
    {
        get => _storage[index];
        set => _storage[index] = value;
    }

    public int Count => _storage.Length;

    public WeekdayArray()
    {
        _storage = new T[7];
    }

    public WeekdayArray(T[] storage)
    {
        if (storage.Length != 7)
        {
            throw new ArgumentException();
        }

        _storage = storage;
    }

    private static int GetIndex(DayOfWeek weekday) =>
        weekday switch
        {
            DayOfWeek.Monday => 0,
            DayOfWeek.Tuesday => 1,
            DayOfWeek.Wednesday => 2,
            DayOfWeek.Thursday => 3,
            DayOfWeek.Friday => 4,
            DayOfWeek.Saturday => 5,
            DayOfWeek.Sunday => 6,
            _ => throw new ArgumentException()
        };

    public IEnumerator<T> GetEnumerator() => _storage.Select(x => x).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    internal class JsonConverter : JsonConverter<WeekdayArray<T>>
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
            JsonSerializer.Serialize(writer, value._storage, options);
        }
    }
}

file class WeekdayArrayJsonConverter : JsonConverterFactory
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
        var converterType = typeof(WeekdayArray<>.JsonConverter).MakeGenericType(itemType);
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
}
