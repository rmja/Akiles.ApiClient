namespace Akiles.ApiClient.Members;

public record MemberEmailInit
{
    public required string Email { get; init; }
    public Dictionary<string, string> Metadata { get; init; } = [];
}
