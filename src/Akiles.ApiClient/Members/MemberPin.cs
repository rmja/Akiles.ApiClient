namespace Akiles.ApiClient.Members;

public record MemberPin
{
    public string Id { get; set; } = null!;

    //public required string OrganizationId { get; set; }
    public required string MemberId { get; set; }
    public int Length { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
}
