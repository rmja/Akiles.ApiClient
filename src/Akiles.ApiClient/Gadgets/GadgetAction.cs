namespace Akiles.ApiClient.Gadgets;

public record GadgetAction
{
    public string Id { get; set; } = null!;
    public required string Name { get; set; }
}
