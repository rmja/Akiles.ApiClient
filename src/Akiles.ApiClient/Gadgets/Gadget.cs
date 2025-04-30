namespace Akiles.ApiClient.Gadgets;

public record Gadget
{
    public string Id { get; set; } = null!;
    public required string OrganizationId { get; set; }
    public required string SiteId { get; set; }
    public required string DeviceId { get; set; }
    public required string Name { get; set; }
    public List<GadgetAction> Actions { get; set; } = [];
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
}
