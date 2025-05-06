namespace Akiles.ApiClient.Schedules;

public record Schedule
{
    public string Id { get; set; } = null!;
    public required string OrganizationId { get; set; }
    public required string Name { get; set; }
    public WeekdayArray<ScheduleWeekday> Weekdays { get; set; } =
        new([.. Enumerable.Range(0, 7).Select(_ => new ScheduleWeekday())]);
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = [];
}
