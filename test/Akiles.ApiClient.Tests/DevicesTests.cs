namespace Akiles.ApiClient.Tests;

public class DevicesTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly IAkilesApiClient _client = fixture.Client;

    [Fact]
    public async Task CanListDevices()
    {
        // Given

        // When
        var devices = await _client
            .Devices.ListDevicesAsync()
            .ToListAsync(TestContext.Current.CancellationToken);

        // Then
        Assert.NotEmpty(devices);
        Assert.Equal(3, devices.Where(x => x.HardwareId is not null).Count());
    }
}
