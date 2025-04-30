using Akiles.ApiClient.Events;

namespace Akiles.ApiClient.Webhooks;

public record WebhookFilterRule(EventObjectType ObjectType, EventVerb Verb);
