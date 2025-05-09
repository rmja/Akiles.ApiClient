using Refit;

namespace Akiles.ApiClient.Gadgets;

internal interface IGadgetsInternal
{
    [Get("/gadgets/{gadgetId}")]
    Task<Gadget> GetGadgetAsync(string gadgetId, CancellationToken cancellationToken);

    [Patch("/gadgets/{gadgetId}")]
    Task<Gadget> EditGadgetAsync(
        string gadgetId,
        GadgetPatch patch,
        CancellationToken cancellationToken
    );

    [Post("/gadgets/{gadgetId}/actions/{actionId}")]
    Task DoGadgetActionAsync(
        string gadgetId,
        string actionId,
        object body,
        CancellationToken cancellationToken
    );
}
