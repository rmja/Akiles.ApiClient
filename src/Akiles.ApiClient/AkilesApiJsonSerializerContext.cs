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
[JsonSerializable(typeof(Event))]
[JsonSerializable(typeof(Gadget))]
[JsonSerializable(typeof(MemberGroup))]
[JsonSerializable(typeof(MemberGroupInit))]
[JsonSerializable(typeof(MemberGroupPatch))]
[JsonSerializable(typeof(MemberCard))]
[JsonSerializable(typeof(MemberCardInit))]
[JsonSerializable(typeof(MemberCardPatch))]
[JsonSerializable(typeof(MemberEmail))]
[JsonSerializable(typeof(MemberEmailInit))]
[JsonSerializable(typeof(MemberEmailPatch))]
[JsonSerializable(typeof(MemberGroupAssociation))]
[JsonSerializable(typeof(MemberGroupAssociationInit))]
[JsonSerializable(typeof(MemberGroupAssociationPatch))]
[JsonSerializable(typeof(MemberPin))]
[JsonSerializable(typeof(MemberPinInit))]
[JsonSerializable(typeof(MemberPinRevealed))]
[JsonSerializable(typeof(Member))]
[JsonSerializable(typeof(MemberInit))]
[JsonSerializable(typeof(MemberPatch))]
[JsonSerializable(typeof(Schedule))]
[JsonSerializable(typeof(Webhook))]
[JsonSerializable(typeof(ErrorResponse))]
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
        typeof(WeekdayArrayJsonConverter<ScheduleWeekday>),
    ]
)]
internal sealed partial class AkilesApiJsonSerializerContext : JsonSerializerContext;
