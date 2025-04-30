using Refit;

namespace Akiles.ApiClient.Schedules;

public interface ISchedules
{
    [Get("/schedules")]
    Task<PagedList<Schedule>> ListSchedulesAsync(
        string? cursor,
        int? limit,
        Sort<Schedule>? sort,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<Schedule> ListSchedulesAsync(Sort<Schedule>? sort = null) =>
        new PaginationEnumerable<Schedule>(
            (cursor, cancellationToken) =>
                ListSchedulesAsync(
                    cursor,
                    Constants.DefaultPaginationLimit,
                    sort,
                    cancellationToken
                )
        );

    [Get("/schedules/{scheduleId}")]
    public Task<Schedule> GetScheduleAsync(
        string scheduleId,
        CancellationToken cancellationToken = default
    );
}
