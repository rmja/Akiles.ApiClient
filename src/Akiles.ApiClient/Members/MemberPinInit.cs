namespace Akiles.ApiClient.Members;

public record MemberPinInit
{
    public int? Length { get; init; }
    public string? Pin { get; init; }
    public Dictionary<string, string> Metadata { get; init; } = [];
}
