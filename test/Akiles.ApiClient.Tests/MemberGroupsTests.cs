using Akiles.ApiClient.MemberGroups;

namespace Akiles.ApiClient.Tests;

public class MemberGroupsTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly IAkilesApiClient _client = fixture.Client;

    [Fact]
    public async Task CanListMemberGroups()
    {
        // Given

        // When
        var groups = await _client
            .MemberGroups.ListMemberGroupsAsync()
            .ToListAsync(TestContext.Current.CancellationToken);

        // Then
        Assert.NotEmpty(groups);
    }

    [Fact]
    public async Task CanGetMemberGroup()
    {
        // Given

        // When
        var group = await _client.MemberGroups.GetMemberGroupAsync(
            "mg_41hmmbk2u95nk44jxdkh",
            TestContext.Current.CancellationToken
        );

        // Then
        Assert.Equal("TEST", group.Name);
    }

    [Fact]
    public async Task CanUpdateMemberGroup()
    {
        // Given
        var patch = new MemberGroupPatch()
        {
            Permissions =
            [
                new()
                {
                    AccessMethods = new MemberGroupPermissionRuleAccessMethodsPatch()
                    {
                        Card = true,
                    },
                },
            ],
        };

        // When
        var group = await _client.MemberGroups.EditMemberGroupAsync(
            "mg_41hmmbk2u95nk44jxdkh",
            patch,
            TestContext.Current.CancellationToken
        );

        // Then
        var permission = Assert.Single(group.Permissions);
        Assert.True(permission.AccessMethods!.Card);
    }
}
