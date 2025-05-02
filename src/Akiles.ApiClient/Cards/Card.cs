namespace Akiles.ApiClient.Cards;

public record Card
{
    public string Id { get; set; } = null!;

    //public required string OrganizationId { get; set; }
    public string? Name { get; set; }

    /// <summary>
    /// ISO14443 UID for the card. Always 4, 7, or 10 bytes, encoded in hex.
    /// </summary>
    public string? Uid { get; init; }
    public string? PrintedCode { get; init; }
    public bool IsDeleted { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
}
