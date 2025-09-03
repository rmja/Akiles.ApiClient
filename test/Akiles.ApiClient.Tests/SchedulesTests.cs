using Akiles.ApiClient.Schedules;

namespace Akiles.ApiClient.Tests;

public class SchedulesTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly IAkilesApiClient _client = fixture.Client;

    [Fact]
    public async Task CanListSchedules()
    {
        // Given

        // When
        var schedules = await _client
            .Schedules.ListSchedulesAsync()
            .ToListAsync(TestContext.Current.CancellationToken);

        // Then
        Assert.Single(schedules);
    }

    [Fact]
    public async Task CanGetSchedule()
    {
        // Given

        // When
        var schedule = await _client.Schedules.GetScheduleAsync(
            "sch_41djhl5mae8q65bysuxh",
            TestContext.Current.CancellationToken
        );

        // Then
        Assert.Equal(7, schedule.Weekdays.Count);
    }

    [Fact]
    public void CanGetRange()
    {
        // Given
        var wednesday = new DateTime(2025, 01, 15, 19, 00, 00, DateTimeKind.Unspecified);
        var schedule = new Schedule() { Name = "", OrganizationId = "" };
        schedule
            .Weekdays[DayOfWeek.Wednesday]
            .Ranges.Add(new(new TimeOnly(19, 00), new TimeOnly(20, 00)));

        // When
        var withinRange00 = schedule.GetRange(wednesday);
        var withinRange59 = schedule.GetRange(wednesday.AddMinutes(59));
        var outsideRange60 = schedule.GetRange(wednesday.AddMinutes(60));

        // Then
        Assert.NotNull(withinRange00);
        Assert.NotNull(withinRange59);
        Assert.Null(outsideRange60);
    }

    [Fact]
    public void CanGetPeriod()
    {
        // Given
        var wednesday = new DateTime(2025, 01, 15, 19, 00, 00, DateTimeKind.Unspecified);
        var schedule = new Schedule() { Name = "", OrganizationId = "" };
        schedule
            .Weekdays[DayOfWeek.Wednesday]
            .Ranges.Add(new(new TimeOnly(19, 00), new TimeOnly(20, 00)));

        // When
        var period = schedule.GetPeriod(wednesday);

        // Then
        Assert.NotNull(period);
        Assert.Equal(new(2025, 01, 15, 19, 00, 00, DateTimeKind.Unspecified), period.Start);
        Assert.Equal(new(2025, 01, 15, 20, 00, 00, DateTimeKind.Unspecified), period.End);
        Assert.Equal(DateTimeKind.Unspecified, period.Start.Kind);
        Assert.Equal(DateTimeKind.Unspecified, period.End.Kind);
    }

    [Fact]
    public void CanGetPeriods_Empty()
    {
        // Given
        var empty = new Schedule() { Name = "", OrganizationId = "" };

        // When
        Assert.Empty(empty.GetEarlierPeriods(DateTime.Now));
        Assert.Empty(empty.GetLaterPeriods(DateTime.Now));

        // Then
    }

    [Fact]
    public void CanGetLaterPeriods()
    {
        // Given
        var wednesday = new DateTime(2025, 01, 15, 19, 00, 00, DateTimeKind.Unspecified);
        var schedule = new Schedule() { Name = "", OrganizationId = "" };
        schedule
            .Weekdays[DayOfWeek.Wednesday]
            .Ranges.Add(new(new TimeOnly(19, 00), new TimeOnly(20, 00)));

        // When
        var startsThisWednesday = schedule
            .GetLaterPeriods(startNotBefore: wednesday)
            .Take(10)
            .ToList();
        var startsNextWednesday = schedule
            .GetLaterPeriods(startNotBefore: wednesday.AddSeconds(1))
            .Take(10)
            .ToList();

        // Then
        Assert.All(
            startsThisWednesday.Concat(startsNextWednesday),
            x =>
            {
                Assert.Equal(new TimeOnly(19, 00), TimeOnly.FromDateTime(x.Start));
                Assert.Equal(new TimeOnly(20, 00), TimeOnly.FromDateTime(x.End));
            }
        );

        Assert.Equal(wednesday, startsThisWednesday.First().Start);
        Assert.Equal(wednesday.AddDays(9 * 7), startsThisWednesday.Last().Start);

        var nextWednesday = wednesday.AddDays(7);
        Assert.Equal(nextWednesday, startsNextWednesday.First().Start);
        Assert.Equal(nextWednesday.AddDays(9 * 7), startsNextWednesday.Last().Start);
    }

    [Fact]
    public void CanGetEarlierPeriods()
    {
        // Given
        var wednesday = new DateTime(2025, 01, 15, 20, 00, 00, DateTimeKind.Unspecified);
        var schedule = new Schedule() { Name = "", OrganizationId = "" };
        schedule
            .Weekdays[DayOfWeek.Wednesday]
            .Ranges.Add(new(new TimeOnly(19, 00), new TimeOnly(20, 00)));

        // When
        var startsThisWednesday = schedule
            .GetEarlierPeriods(endNotAfter: wednesday)
            .Take(10)
            .ToList();
        var startsPreviousWednesday = schedule
            .GetEarlierPeriods(endNotAfter: wednesday.AddSeconds(-1))
            .Take(10)
            .ToList();

        // Then
        Assert.All(
            startsThisWednesday.Concat(startsPreviousWednesday),
            x =>
            {
                Assert.Equal(new TimeOnly(19, 00), TimeOnly.FromDateTime(x.Start));
                Assert.Equal(new TimeOnly(20, 00), TimeOnly.FromDateTime(x.End));
            }
        );

        Assert.Equal(wednesday, startsThisWednesday.First().End);
        Assert.Equal(wednesday.AddDays(-9 * 7), startsThisWednesday.Last().End);

        var previousWednesday = wednesday.AddDays(-7);
        Assert.Equal(previousWednesday, startsPreviousWednesday.First().End);
        Assert.Equal(previousWednesday.AddDays(-9 * 7), startsPreviousWednesday.Last().End);
    }
}
