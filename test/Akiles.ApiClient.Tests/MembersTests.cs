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
        var members = await _client.Members.ListMembersAsync().ToListAsync();

        // Then
        Assert.NotEmpty(members);
    }

    [Fact]
    public async Task CanListMembersWithExpand()
    {
        // Given

        // When
        var members = await _client
            .Members.ListMembersAsync(expand: MembersExpand.Emails)
            .ToListAsync();

        // Then
        Assert.NotEmpty(members);
        Assert.Contains(members, x => x.Emails is not null);
    }
}
