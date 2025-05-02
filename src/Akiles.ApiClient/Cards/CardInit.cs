using System.ComponentModel.DataAnnotations;

namespace Akiles.ApiClient.Cards;

public record CardInit
{
    public string? Name { get; init; }

    /// <summary>
    /// ISO14443 UID for the card. Always 4, 7, or 10 bytes, encoded in hex.
    /// </summary>
    public string? Uid { get; init; }
    public string? PrintedCode { get; init; }

    public Dictionary<string, string?> Metadata { get; init; } = [];

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Uid is null && PrintedCode is null)
        {
            yield return new ValidationResult(
                "One of Uid or PrintedCode must be present",
                [nameof(Uid), nameof(PrintedCode)]
            );
        }
    }
}
