using Akiles.ApiClient.Schedules;
using Cursor;
using Refit;

namespace Akiles.ApiClient;

public interface ISchedules
{
    [Get("/schedules")]
    [GenerateEnumerator]
    Task<PagedList<Schedule>> ListSchedulesAsync(
        Sort<Schedule>? sort = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );

    [Get("/schedules/{scheduleId}")]
    public Task<Schedule> GetScheduleAsync(
        string scheduleId,
        CancellationToken cancellationToken = default
    );
}
