using System.Reflection;
using Refit;

namespace Akiles.ApiClient.ParameterFormatters;

internal abstract class UrlParameterFormatter : IUrlParameterFormatter
{
    public abstract bool CanConvert(Type typeToConvert);

    public abstract string? Format(
        object? value,
        ICustomAttributeProvider attributeProvider,
        Type type
    );
}

internal abstract class UrlParameterFormatter<T> : UrlParameterFormatter
{
    public virtual bool HandleNull { get; } = false;

    public override bool CanConvert(Type typeToConvert) =>
        typeof(T).IsAssignableFrom(typeToConvert);

    public override string? Format(
        object? value,
        ICustomAttributeProvider attributeProvider,
        Type type
    )
    {
        if (HandleNull)
        {
            return Format((T)value!);
        }

        if (value is null)
        {
            return null;
        }

        return Format((T)value);
    }

    protected abstract string? Format(T value);
}
