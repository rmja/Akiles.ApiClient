using Akiles.ApiClient.Members;

namespace Akiles.ApiClient.Tests;

public class MembersTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly IAkilesApiClient _client = fixture.Client;

    [Fact]
    public async Task CanListMembers()
    {
        // Given

        // When
        var members = await _client
            .Members.EnumerateMembersAsync()
            .ToListAsync(TestContext.Current.CancellationToken);

        // Then
        Assert.NotEmpty(members);
    }

    [Fact]
    public async Task CanListMembers_WithMetadataFilter()
    {
        // Given

        // When
        var members = await _client
            .Members.EnumerateMembersAsync(
                filter: new() { Metadata = new() { ["laesoe_card_color"] = "red" } }
            )
            .ToListAsync(TestContext.Current.CancellationToken);

        // Then
        Assert.NotEmpty(members);
        Assert.DoesNotContain(
            members,
            x => x.Metadata.GetValueOrDefault("laesoe_card_color") != "red"
        );
    }

    [Fact]
    public async Task CanListMembersWithExpand()
    {
        // Given

        // When
        var members = await _client
            .Members.EnumerateMembersAsync(expand: MembersExpand.Emails)
            .ToListAsync(TestContext.Current.CancellationToken);

        // Then
        Assert.NotEmpty(members);
        Assert.Contains(members, x => x.Emails is not null);
    }
}
