using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Akiles.ApiClient.JsonConverters;
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
                new OptionJsonConverter()
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
