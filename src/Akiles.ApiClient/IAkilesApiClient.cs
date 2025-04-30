using Akiles.ApiClient.Devices;
using Akiles.ApiClient.Events;
using Akiles.ApiClient.Gadgets;
using Akiles.ApiClient.MemberGroups;
using Akiles.ApiClient.Members;
using Akiles.ApiClient.Schedules;
using Akiles.ApiClient.Webhooks;

namespace Akiles.ApiClient;

public interface IAkilesApiClient
{
    IDevices Devices { get; }
    IEvents Events { get; }
    IGadgets Gadgets { get; }
    IMembers Members { get; }
    IMemberGroups MemberGroups { get; }
    ISchedules Schedules { get; }
    IWebhooks Webhooks { get; }
}
