using Akiles.ApiClient.Devices;
using Cursor;
using Refit;

namespace Akiles.ApiClient;

public interface IDevices
{
    [Get("/devices")]
    [GenerateEnumerator]
    Task<PagedList<Device>> ListDevicesAsync(
        Sort<Device>? sort = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );

    [Get("/devices/{deviceId}")]
    Task<Device> GetDeviceAsync(string deviceId, CancellationToken cancellationToken = default);
}
