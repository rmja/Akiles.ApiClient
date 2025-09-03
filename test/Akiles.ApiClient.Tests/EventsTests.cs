namespace Akiles.ApiClient.Tests;

public class EventsTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly IAkilesApiClient _client = fixture.Client;

    [Fact]
    public async Task CanListEvents()
    {
        // Given

        // When
        var events = await _client
            .Events.ListEventsAsync()
            .TakeAsync(200)
            .ToListAsync(TestContext.Current.CancellationToken);

        // Then
        Assert.NotEmpty(events);
        Assert.True(events.Count <= 200);
        Assert.All(events, x => Assert.Equal(DateTimeKind.Utc, x.CreatedAt.Kind));
    }

    [Fact]
    public async Task CanListEvents_WithCreatedAtRangeFilter()
    {
        // Given
        var notBefore = new DateTimeOffset(2025, 04, 01, 00, 00, 00, TimeSpan.FromHours(2));
        var notAfter = new DateTimeOffset(2025, 05, 01, 00, 00, 00, TimeSpan.FromHours(2));

        // When
        var events = await _client
            .Events.ListEventsAsync(
                filter: new()
                {
                    CreatedAt = new()
                    {
                        GreaterThanOrEqual = notBefore,
                        LessThanOrEqual = notAfter,
                    },
                }
            )
            .ToListAsync(TestContext.Current.CancellationToken);

        // Then
        Assert.Equal(3525, events.Count);
        Assert.All(events, x => Assert.InRange(x.CreatedAt, notBefore, notAfter));
    }
}
