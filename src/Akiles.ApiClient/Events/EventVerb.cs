using System.Text.Json.Serialization;
using Akiles.ApiClient.JsonConverters;

namespace Akiles.ApiClient.Events;

[JsonConverter(typeof(SnakeCaseLowerJsonStringEnumConverter<EventVerb>))]
public enum EventVerb
{
    Create,
    Edit,
    Delete,
    Use,
    Reveal,
}
