using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using LanguageExt;

namespace Akiles.ApiClient;

public static class AkilesApiJsonSerializerOptions
{
    public static JsonSerializerOptions Value { get; } = CreateOptions();

    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions(AkilesApiJsonSerializerContext.Default.Options);
        options.TypeInfoResolverChain.Insert(
            0,
            new DefaultJsonTypeInfoResolver() { Modifiers = { ExcludeOptionNoneVariant } }
        );
        return options;
    }

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
