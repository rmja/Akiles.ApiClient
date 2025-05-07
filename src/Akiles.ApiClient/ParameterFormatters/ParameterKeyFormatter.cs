using System.Text.Json;
using Refit;

namespace Akiles.ApiClient.ParameterFormatters;

internal class ParameterKeyFormatter : IUrlParameterKeyFormatter
{
    public JsonNamingPolicy NamingPolicy { get; set; } = JsonNamingPolicy.SnakeCaseLower;

    public string Format(string key) => NamingPolicy.ConvertName(key);
}
