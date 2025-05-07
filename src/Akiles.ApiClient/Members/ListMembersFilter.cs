namespace Akiles.ApiClient.Members;

public record ListMembersFilter
{
    public IsDeleted? IsDeleted { get; set; }
    public string? Email { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}
