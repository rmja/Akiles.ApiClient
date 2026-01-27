using Akiles.ApiClient.Webhooks;
using Cursor;
using Refit;

namespace Akiles.ApiClient;

public interface IWebhooks
{
    [Get("/webhooks")]
    [GenerateEnumerator]
    Task<PagedList<Webhook>> ListWebhooksAsync(
        Sort<Webhook>? sort,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );

    [Get("/webhooks/{webhookId}")]
    Task<Webhook> GetWebhookAsync(string webhookId, CancellationToken cancellationToken = default);

    [Post("/webhooks")]
    Task<Webhook> CreateWebhookAsync(
        WebhookInit webhook,
        CancellationToken cancellationToken = default
    );
}
