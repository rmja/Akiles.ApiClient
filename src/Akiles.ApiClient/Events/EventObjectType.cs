using System.Text.Json.Serialization;
using Akiles.ApiClient.JsonConverters;

namespace Akiles.ApiClient.Events;

[JsonConverter(typeof(SnakeCaseLowerJsonStringEnumConverter<EventObjectType>))]
public enum EventObjectType
{
    Device,
    Gadget,
    GadgetAction,
    Member,
    MemberEmail,
    MemberMagicLink,
    MemberGroup,
    MemberGroupAssociation,
    MemberPin,
    MemberCard,
    MemberToken,
    Organization,
    Site,
    Webhook,
    Hardware,
    Card
}
