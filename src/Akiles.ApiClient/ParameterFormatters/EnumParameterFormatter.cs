using System.Text.Json;

namespace Akiles.ApiClient.ParameterFormatters;

internal class EnumParameterFormatter<TEnum> : UrlParameterFormatter<TEnum>
    where TEnum : struct, Enum
{
    public JsonNamingPolicy NamingPolicy { get; set; } = JsonNamingPolicy.SnakeCaseLower;

    static readonly TEnum[]? _flags = typeof(TEnum).IsDefined(typeof(FlagsAttribute), false)
        ? [.. Enum.GetValues<TEnum>().Where(x => !x.Equals(default(TEnum)))]
        : null;

    protected override string? Format(TEnum value)
    {
        if (_flags is null)
        {
            var name = Enum.GetName(value);
            return name is not null ? NamingPolicy.ConvertName(name) : null;
        }
        var flags = _flags.Where(flag => value.HasFlag(flag));
        if (!flags.Any())
        {
            return null;
        }

        var names = flags.Select(x => NamingPolicy.ConvertName(Enum.GetName(x)!));
        return string.Join(",", names);
    }
}
