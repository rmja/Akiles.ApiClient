namespace Akiles.ApiClient.Members;

public record Member
{
    public string Id { get; set; } = null!;
    public required string OrganizationId { get; set; }
    public required string Name { get; set; }
    public DateTime? StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public string Language { get; set; } = "";
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
    public List<MemberCard>? Cards { get; init; }
    public List<MemberEmail>? Emails { get; init; }
    public List<MemberGroupAssociation>? GroupAssociations { get; init; }
}
