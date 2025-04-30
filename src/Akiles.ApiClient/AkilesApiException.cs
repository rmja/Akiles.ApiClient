using System.Net;

namespace Akiles.ApiClient;

public class AkilesApiException(string message) : Exception(message)
{
    public required Uri RequestUri { get; init; }
    public required HttpStatusCode StatusCode { get; init; }
    public required string ErrorType { get; init; }
    public required Dictionary<string, string> ErrorArgs { get; set; }
}
