using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using LanguageExt;

namespace Akiles.ApiClient;

public static class AkilesApiJsonSerializerOptions
{
    public static JsonSerializerOptions Value { get; } =
        new JsonSerializerOptions(AkilesApiJsonSerializerContext.Default.Options)
        {
            TypeInfoResolver = AkilesApiJsonSerializerContext.Default.WithAddedModifier(
                ExcludeOptionNoneVariant
            )
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
                property.ShouldSerialize = static (_, value) => IsSome(value!);
            }
        }

        static bool IsSome(object value)
        {
#pragma warning disable IL2072
            var defaultValue = Activator.CreateInstance(value.GetType());
#pragma warning restore IL2072
            return !value.Equals(defaultValue);
        }
    }
}
