namespace Akiles.ApiClient.Webhooks;

public static class WebhookConstants
{
    /// <summary>
    /// The name of the header containing the signature as hex of the webhook body.
    /// </summary>
    public const string SignatureHeaderName = "x-akiles-sig-sha256";
}
