using Refit;

namespace Akiles.ApiClient.Devices;

public interface IDevices
{
    [Get("/devices")]
    Task<PagedList<Device>> ListDevicesAsync(
        string? cursor,
        int? limit,
        Sort<Device>? sort,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<Device> ListDevicesAsync(Sort<Device>? sort = null) =>
        new PaginationEnumerable<Device>(
            (cursor, cancellationToken) =>
                ListDevicesAsync(cursor, Constants.DefaultPaginationLimit, sort, cancellationToken)
        );

    [Get("/devices/{deviceId}")]
    Task<Device> GetDeviceAsync(string deviceId, CancellationToken cancellationToken = default);
}
