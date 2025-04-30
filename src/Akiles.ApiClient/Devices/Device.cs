namespace Akiles.ApiClient.Devices;

public record Device
{
    public string Id { get; set; } = null!;
    public required string OrganizationId { get; set; }
    public required string SiteId { get; set; }
    public required string Name { get; set; }
    public required string ProductId { get; set; }
    public required string RevisionId { get; set; }
    public string? HardwareId { get; set; }
    public required DeviceStatus Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
}
