namespace Akiles.ApiClient.Tests;

public class EventsTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly IAkilesApiClient _client = fixture.Client;

    [Fact]
    public async Task CanListEvents()
    {
        // Given

        // When
        var events = await _client.Events.ListEventsAsync().TakeAsync(200).ToListAsync();

        // Then
        Assert.NotEmpty(events);
        Assert.True(events.Count <= 200);
        Assert.All(events, x => Assert.Equal(DateTimeKind.Utc, x.CreatedAt.Kind));
    }
}
