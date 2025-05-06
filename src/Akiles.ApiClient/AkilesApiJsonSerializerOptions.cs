using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using LanguageExt;

namespace Akiles.ApiClient;

public static class AkilesApiJsonSerializerOptions
{
    public static JsonSerializerOptions Value { get; } = CreateOptions();

    [UnconditionalSuppressMessage(
        "ReflectionAnalysis",
        "IL2026:RequiresUnreferencedCode",
        Justification = "All types are already marked as JsonSerializable."
    )]
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
