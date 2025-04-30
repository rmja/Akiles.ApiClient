namespace Akiles.ApiClient.Members;

public record MemberPinRevealed : MemberPin
{
    public required string Pin { get; set; }
}
