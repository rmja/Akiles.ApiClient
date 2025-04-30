namespace Akiles.ApiClient.Members;

public record MemberGroupAssociation
{
    public string Id { get; set; } = null!;

    //public required string OrganizationId { get; set; }
    public required string MemberId { get; set; }
    public required string MemberGroupId { get; set; }
    public DateTime? StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
    public Member? Member { get; set; }
}
