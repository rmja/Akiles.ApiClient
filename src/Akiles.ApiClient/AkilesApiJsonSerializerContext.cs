using System.Text.Json.Serialization;
using Akiles.ApiClient.Cards;
using Akiles.ApiClient.Devices;
using Akiles.ApiClient.Events;
using Akiles.ApiClient.Gadgets;
using Akiles.ApiClient.JsonConverters;
using Akiles.ApiClient.MemberGroups;
using Akiles.ApiClient.Members;
using Akiles.ApiClient.Schedules;
using Akiles.ApiClient.Webhooks;

namespace Akiles.ApiClient;

[JsonSerializable(typeof(Card))]
[JsonSerializable(typeof(CardInit))]
[JsonSerializable(typeof(CardPatch))]
[JsonSerializable(typeof(Device))]
[JsonSerializable(typeof(ErrorResponse))]
[JsonSerializable(typeof(Event))]
[JsonSerializable(typeof(Gadget))]
[JsonSerializable(typeof(GadgetPatch))]
[JsonSerializable(typeof(List<MemberCard>))]
[JsonSerializable(typeof(List<MemberEmail>))]
[JsonSerializable(typeof(List<MemberGroupAssociation>))]
[JsonSerializable(typeof(List<MemberGroupPermissionRule>))]
[JsonSerializable(typeof(List<MemberGroupPermissionRulePatch>))]
[JsonSerializable(typeof(List<ScheduleRange>))]
[JsonSerializable(typeof(List<WebhookFilterRule>))]
[JsonSerializable(typeof(ListEventsFilter))]
[JsonSerializable(typeof(ListEventsObjectFilter))]
[JsonSerializable(typeof(ListEventsSubjectFilter))]
[JsonSerializable(typeof(ListMembersFilter))]
[JsonSerializable(typeof(Member))]
[JsonSerializable(typeof(MemberCard))]
[JsonSerializable(typeof(MemberCardInit))]
[JsonSerializable(typeof(MemberCardPatch))]
[JsonSerializable(typeof(MemberEmail))]
[JsonSerializable(typeof(MemberEmailInit))]
[JsonSerializable(typeof(MemberEmailPatch))]
[JsonSerializable(typeof(MemberGroup))]
[JsonSerializable(typeof(MemberGroupAssociation))]
[JsonSerializable(typeof(MemberGroupAssociationInit))]
[JsonSerializable(typeof(MemberGroupAssociationPatch))]
[JsonSerializable(typeof(MemberGroupInit))]
[JsonSerializable(typeof(MemberGroupPatch))]
[JsonSerializable(typeof(MemberGroupPermissionRule))]
[JsonSerializable(typeof(MemberGroupPermissionRuleAccessMethods))]
[JsonSerializable(typeof(MemberGroupPermissionRuleAccessMethodsPatch))]
[JsonSerializable(typeof(MemberGroupPermissionRulePatch))]
[JsonSerializable(typeof(MemberInit))]
[JsonSerializable(typeof(MemberPatch))]
[JsonSerializable(typeof(MemberPin))]
[JsonSerializable(typeof(MemberPinInit))]
[JsonSerializable(typeof(MemberPinRevealed))]
[JsonSerializable(typeof(PagedList<Card>))]
[JsonSerializable(typeof(PagedList<Device>))]
[JsonSerializable(typeof(PagedList<Event>))]
[JsonSerializable(typeof(PagedList<Member>))]
[JsonSerializable(typeof(PagedList<MemberCard>))]
[JsonSerializable(typeof(PagedList<MemberEmail>))]
[JsonSerializable(typeof(PagedList<MemberGroup>))]
[JsonSerializable(typeof(PagedList<MemberGroupAssociation>))]
[JsonSerializable(typeof(PagedList<Schedule>))]
[JsonSerializable(typeof(PagedList<Webhook>))]
[JsonSerializable(typeof(Schedule))]
[JsonSerializable(typeof(ScheduleRange))]
[JsonSerializable(typeof(ScheduleWeekday))]
[JsonSerializable(typeof(WeekdayArray<ScheduleWeekday>))]
[JsonSerializable(typeof(Webhook))]
[JsonSerializable(typeof(WebhookFilterRule))]
[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
    Converters =
    [
        typeof(TimeOnlyJsonConverter),
        typeof(OptionJsonConverter<bool>),
        typeof(OptionJsonConverter<string>),
        typeof(OptionJsonConverter<DateTime>),
        typeof(OptionJsonConverter<DateTime?>),
        typeof(PagedListJsonConverter<Card>),
        typeof(PagedListJsonConverter<Device>),
        typeof(PagedListJsonConverter<Event>),
        typeof(PagedListJsonConverter<Gadget>),
        typeof(PagedListJsonConverter<MemberGroup>),
        typeof(PagedListJsonConverter<MemberCard>),
        typeof(PagedListJsonConverter<MemberEmail>),
        typeof(PagedListJsonConverter<MemberGroupAssociation>),
        typeof(PagedListJsonConverter<MemberPin>),
        typeof(PagedListJsonConverter<Member>),
        typeof(PagedListJsonConverter<Schedule>),
        typeof(PagedListJsonConverter<Webhook>),
        typeof(SnakeCaseLowerJsonStringEnumConverter<EventObjectType>),
        typeof(SnakeCaseLowerJsonStringEnumConverter<EventVerb>),
        typeof(SnakeCaseLowerJsonStringEnumConverter<MemberGroupPermissionRulePresence>),
        typeof(WeekdayArrayJsonConverter<ScheduleWeekday>),
    ]
)]
internal sealed partial class AkilesApiJsonSerializerContext : JsonSerializerContext;
