using Refit;

namespace Akiles.ApiClient.Gadgets;

public interface IGadgets
{
    [Get("/gadgets/{gadgetId}")]
    Task<Gadget> GetGadgetAsync(string gadgetId, CancellationToken cancellationToken = default);

    [Patch("/gadgets/{gadgetId}")]
    Task<Gadget> EditGadgetAsync(
        string gadgetId,
        GadgetPatch patch,
        CancellationToken cancellationToken = default
    );

    Task DoGadgetActionAsync(
        string gadgetId,
        string actionId,
        CancellationToken cancellationToken = default
    ) => DoGadgetActionAsync(gadgetId, actionId, new object(), cancellationToken);

    [Post("/gadgets/{gadgetId}/actions/{actionId}")]
    internal Task DoGadgetActionAsync(
        string gadgetId,
        string actionId,
        object body,
        CancellationToken cancellationToken = default
    );
}
