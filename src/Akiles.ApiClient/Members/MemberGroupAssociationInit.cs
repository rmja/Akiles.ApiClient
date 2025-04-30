namespace Akiles.ApiClient.Members;

public record MemberGroupAssociationInit
{
    public required string MemberGroupId { get; set; }
    public DateTime? StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
}
