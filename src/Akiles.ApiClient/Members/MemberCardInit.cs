using System.ComponentModel.DataAnnotations;

namespace Akiles.ApiClient.Members;

public record MemberCardInit : IValidatableObject
{
    public string? CardId { get; init; }
    public string? Uid { get; init; }
    public string? PrintedCode { get; init; }
    public Dictionary<string, string> Metadata { get; init; } = [];

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CardId is null && Uid is null && PrintedCode is null)
        {
            yield return new ValidationResult(
                "One of CardId, Uid or PrintedCode must be present",
                [nameof(CardId), nameof(Uid), nameof(PrintedCode)]
            );
        }
    }
}
