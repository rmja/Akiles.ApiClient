using Refit;

namespace Akiles.ApiClient;

public record RangeFilter<T>
    where T : struct
{
    [AliasAs(":gt")]
    public T? GreaterThan { get; set; }

    [AliasAs(":ge")]
    public T? GreaterThanOrEqual { get; set; }

    [AliasAs(":lt")]
    public T? LessThan { get; set; }

    [AliasAs(":le")]
    public T? LessThanOrEqual { get; set; }
}
