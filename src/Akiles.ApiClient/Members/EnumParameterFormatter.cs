using System.Reflection;
using System.Text.Json;
using Refit;

namespace Akiles.ApiClient;

[AttributeUsage(AttributeTargets.Enum)]
internal class EnumParameterFormatterAttribute<TEnum> : Attribute, IUrlParameterFormatter
    where TEnum : struct, Enum
{
    public JsonNamingPolicy NamingPolicy { get; set; } = JsonNamingPolicy.SnakeCaseLower;

    static readonly TEnum[]? _flags = typeof(TEnum).IsDefined(typeof(FlagsAttribute), false)
        ? Enum.GetValues<TEnum>().Where(x => !x.Equals(default(TEnum))).ToArray()
        : null;

    public string? Format(object? value, ICustomAttributeProvider attributeProvider, Type type) =>
        value is TEnum enumValue ? Format(enumValue) : null;

    public string? Format(TEnum value)
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
