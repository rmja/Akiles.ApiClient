using System.Collections;
using System.Text.Json.Serialization;
using Akiles.ApiClient.JsonConverters;

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
            throw new ArgumentException(null, nameof(storage));
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
            _ => throw new ArgumentException(null, nameof(weekday))
        };

    internal T[] GetArray() => _storage;

    public IEnumerator<T> GetEnumerator() => _storage.Select(x => x).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
