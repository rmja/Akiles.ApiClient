using Refit;

namespace Akiles.ApiClient.Members;

public record ListMembersFilter
{
    public IsDeleted? IsDeleted { get; set; }
    public string? Email { get; set; }

    [AliasAs("metadata.")]
    public Dictionary<string, string>? Metadata { get; set; }

    public RangeFilter<DateTimeOffset>? CreatedAt { get; set; }
}
