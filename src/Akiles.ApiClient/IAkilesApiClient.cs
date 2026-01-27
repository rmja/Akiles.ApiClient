namespace Akiles.ApiClient;

public interface IAkilesApiClient
{
    ICards Cards { get; }
    IDevices Devices { get; }
    IEvents Events { get; }
    IGadgets Gadgets { get; }
    IMembers Members { get; }
    IMemberGroups MemberGroups { get; }
    ISchedules Schedules { get; }
    IWebhooks Webhooks { get; }
}
