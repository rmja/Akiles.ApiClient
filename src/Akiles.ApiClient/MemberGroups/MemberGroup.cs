namespace Akiles.ApiClient.MemberGroups;

public record MemberGroup
{
    public string Id { get; set; } = null!;
    public required string OrganizationId { get; set; }
    public required string Name { get; init; }
    public List<MemberGroupPermissionRule> Permissions { get; set; } = [];
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
}
