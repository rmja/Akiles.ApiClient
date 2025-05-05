using System.Text.Json.Serialization;
using Akiles.ApiClient.JsonConverters;

namespace Akiles.ApiClient.MemberGroups;

[JsonConverter(typeof(SnakeCaseLowerJsonStringEnumConverter<MemberGroupPermissionRulePresence>))]
public enum MemberGroupPermissionRulePresence
{
    None,
    Gps,
}
