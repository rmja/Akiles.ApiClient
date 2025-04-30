namespace Akiles.ApiClient.Webhooks;

public record Webhook
{
    public string Id { get; set; } = null!;

    //public required string OrganizationId { get; set; }
    public List<WebhookFilterRule> Filter { get; set; } = [];
    public required string Url { get; set; }
    public string? Secret { get; set; }
    public required bool IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}
