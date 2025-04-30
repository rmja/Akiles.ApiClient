namespace Akiles.ApiClient.Webhooks;

public record WebhookInit
{
    public List<WebhookFilterRule> Filter { get; init; } = [];
    public required string Url { get; init; }
    public required bool IsEnabled { get; init; }
}
