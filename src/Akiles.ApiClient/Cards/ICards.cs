using Refit;

namespace Akiles.ApiClient.Cards;

public interface ICards
{
    [Get("/cards")]
    Task<PagedList<Card>> ListCardsAsync(
        string? cursor,
        int? limit,
        Sort<Card>? sort,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<Card> ListCardsAsync(Sort<Card>? sort = null) =>
        new PaginationEnumerable<Card>(
            (cursor, cancellationToken) =>
                ListCardsAsync(cursor, Constants.DefaultPaginationLimit, sort, cancellationToken)
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
