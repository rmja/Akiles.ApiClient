namespace Akiles.ApiClient.Gadgets;

internal class GadgetsWrapper(IGadgetsInternal inner) : IGadgets
{
    private static readonly object _emptyBody = new();

    public Task<Gadget> GetGadgetAsync(
        string gadgetId,
        CancellationToken cancellationToken = default
    ) => inner.GetGadgetAsync(gadgetId, cancellationToken);

    public Task<Gadget> EditGadgetAsync(
        string gadgetId,
        GadgetPatch patch,
        CancellationToken cancellationToken = default
    ) => inner.EditGadgetAsync(gadgetId, patch, cancellationToken);

    public Task DoGadgetActionAsync(
        string gadgetId,
        string actionId,
        CancellationToken cancellationToken = default
    ) => inner.DoGadgetActionAsync(gadgetId, actionId, _emptyBody, cancellationToken);
}
