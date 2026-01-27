using Akiles.ApiClient.Cards;
using Cursor;
using Refit;

namespace Akiles.ApiClient;

public interface ICards
{
    [Get("/cards")]
    [GenerateEnumerator]
    Task<PagedList<Card>> ListCardsAsync(
        Sort<Card>? sort = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );

    [Get("/cards/{cardId}")]
    Task<Card> GetCardAsync(string cardId, CancellationToken cancellationToken = default);

    [Post("/cards")]
    Task<Card> CreateCardAsync(CardInit card, CancellationToken cancellationToken = default);

    [Patch("/cards/{cardId}")]
    Task<Card> EditCardAsync(
        string cardId,
        CardPatch patch,
        CancellationToken cancellationToken = default
    );

    [Delete("/cards/{cardId}")]
    Task<Card> DeleteCardAsync(string cardId, CancellationToken cancellationToken = default);
}
