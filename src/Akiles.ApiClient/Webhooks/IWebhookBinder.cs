using Akiles.ApiClient.Events;

namespace Akiles.ApiClient.Webhooks;

public interface IWebhookBinder
{
    Task<Event?> BindEventAsync(
        Stream body,
        string signatureHex,
        CancellationToken cancellationToken
    );
}
