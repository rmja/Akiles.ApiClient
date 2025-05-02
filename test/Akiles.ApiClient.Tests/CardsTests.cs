namespace Akiles.ApiClient.Tests;

public class CardsTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly IAkilesApiClient _client = fixture.Client;

    [Fact]
    public async Task CanListCards()
    {
        // Given

        // When
        var cards = await _client.Cards.ListCardsAsync().ToListAsync();

        // Then
        Assert.Empty(cards);
    }
}
