namespace Akiles.ApiClient.Schedules;

public record ScheduleWeekday
{
    public List<ScheduleRange> Ranges { get; set; } = [];
}
