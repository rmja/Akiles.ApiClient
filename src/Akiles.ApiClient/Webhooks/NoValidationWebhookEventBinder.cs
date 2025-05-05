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
        var evnt = await JsonSerializer.DeserializeAsync(
            body,
            AkilesApiJsonSerializerContext.Default.Event,
            cancellationToken
        );
        return evnt;
    }
}
