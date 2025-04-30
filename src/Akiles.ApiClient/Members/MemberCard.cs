namespace Akiles.ApiClient.Members;

public record MemberCard
{
    public string Id { get; set; } = null!;

    //public required string OrganizationId { get; set; }
    public required string MemberId { get; set; }
    public required string CardId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
}
