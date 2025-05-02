namespace Akiles.ApiClient.MemberGroups;

public record MemberGroupInit
{
    public required string Name { get; init; }
    public List<MemberGroupPermissionRule> Permissions { get; init; } = [];
    public Dictionary<string, string?> Metadata { get; init; } = [];
}
