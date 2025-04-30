using Akiles.ApiClient.Members;

namespace Akiles.ApiClient.Tests;

public class SchedulesTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly IAkilesApiClient _client = fixture.Client;

    [Fact]
    public async Task CanListSchedules()
    {
        // Given

        // When
        var schedules = await _client.Schedules.ListSchedulesAsync().ToListAsync();

        // Then
        Assert.Single(schedules);
    }

    [Fact]
    public async Task CanGetSchedule()
    {
        // Given

        // When
        var schedule = await _client.Schedules.GetScheduleAsync("sch_41djhl5mae8q65bysuxh");

        // Then
        Assert.Equal(7, schedule.Weekdays.Count);
    }
}
