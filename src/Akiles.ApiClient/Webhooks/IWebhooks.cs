using Refit;

namespace Akiles.ApiClient.Webhooks;

public interface IWebhooks
{
    [Get("/webhooks")]
    Task<PagedList<Webhook>> ListWebhooksAsync(
        string? cursor,
        int? limit,
        Sort<Webhook>? sort,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<Webhook> ListWebhooksAsync(Sort<Webhook>? sort = null) =>
        new PaginationEnumerable<Webhook>(
            (cursor, cancellationToken) =>
                ListWebhooksAsync(cursor, Constants.DefaultPaginationLimit, sort, cancellationToken)
        );

    [Get("/webhooks/{webhookId}")]
    Task<Webhook> GetWebhookAsync(string webhookId, CancellationToken cancellationToken = default);

    [Post("/webhooks")]
    Task<Webhook> CreateWebhookAsync(
        WebhookInit webhook,
        CancellationToken cancellationToken = default
    );
}
