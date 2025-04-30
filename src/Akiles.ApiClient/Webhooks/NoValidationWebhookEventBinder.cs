using System.Text.Json;
using Akiles.ApiClient.Events;

namespace Akiles.ApiClient.Webhooks;

public class NoValidationWebhookEventBinder : IWebhookBinder
{
    public async Task<Event?> BindEventAsync(
        Stream body,
        string signatureHex,
        CancellationToken cancellationToken
    )
    {
        var evnt = await JsonSerializer.DeserializeAsync<Event>(
            body,
            AkilesApiJsonSerializerOptions.Value,
            cancellationToken
        );
        return evnt;
    }
}
