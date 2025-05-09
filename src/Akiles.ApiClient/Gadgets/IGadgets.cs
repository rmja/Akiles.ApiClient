namespace Akiles.ApiClient.Gadgets;

public interface IGadgets
{
    Task<Gadget> GetGadgetAsync(string gadgetId, CancellationToken cancellationToken = default);

    Task<Gadget> EditGadgetAsync(
        string gadgetId,
        GadgetPatch patch,
        CancellationToken cancellationToken = default
    );

    Task DoGadgetActionAsync(
        string gadgetId,
        string actionId,
        CancellationToken cancellationToken = default
    );
}
