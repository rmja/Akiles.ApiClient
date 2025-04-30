namespace Akiles.ApiClient;

internal class ErrorResponse
{
    public required string Type { get; set; }
    public required string Message { get; set; }
    public required Dictionary<string, string> Args { get; set; }
}
