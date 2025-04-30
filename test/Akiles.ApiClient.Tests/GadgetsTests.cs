namespace Akiles.ApiClient.Tests;

public class GadgetsTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    const string TestGadgetId = "gad_41fjfn595rab3nhyahd1";

    private readonly IAkilesApiClient _client = fixture.Client;

    [Fact]
    public async Task CanDoGadgetAction()
    {
        // Given

        // When
        await _client.Gadgets.DoGadgetActionAsync(TestGadgetId, "open");

        // Then
    }
}
