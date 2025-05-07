using System.Reflection;
using Refit;

namespace Akiles.ApiClient.ParameterFormatters;

internal class CompositeParameterFormatter(params IUrlParameterFormatter[] formatters)
    : IUrlParameterFormatter
{
    public string? Format(object? value, ICustomAttributeProvider attributeProvider, Type type)
    {
        var typeToConvert = value?.GetType() ?? type;
        foreach (var formatter in formatters)
        {
            if (
                formatter is UrlParameterFormatter urlParameterFormatter
                && !urlParameterFormatter.CanConvert(typeToConvert)
            )
            {
                continue;
            }

            return formatter.Format(value, attributeProvider, type);
        }

        return null;
    }
}
