using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Akiles.ApiClient.Events;
using Microsoft.Extensions.Logging;

namespace Akiles.ApiClient.Webhooks;

public class WebhookEventBinder(string webhookSecret, ILogger<WebhookEventBinder> logger)
    : IWebhookBinder
{
    private readonly byte[] _secret = Encoding.UTF8.GetBytes(webhookSecret);

    /// <summary>
    /// Bind a webhook request to an <see cref="Event"/>.
    /// </summary>
    /// <param name="body">The webhook request body</param>
    /// <param name="signatureHex">The value of the <see cref="WebhookConstants.SignatureHeaderName"/> webhook header</param>
    /// <returns>The webhook event if correctly signed; <see langword="null"/> otherwise</returns>
    public async Task<Event?> BindEventAsync(
        Stream body,
        string signatureHex,
        CancellationToken cancellationToken
    )
    {
        var expectedSignature = Convert.FromHexString(signatureHex);
        var (evnt, actualSignature) = await DeserializeWithSignatureAsync<Event>(
            body,
            cancellationToken
        );

        if (!actualSignature.SequenceEqual(expectedSignature))
        {
            logger.LogWarning(
                "Signature mismatch! Expected: {ExpectedSignature}, actual: {ActualSignature}",
                Convert.ToHexString(expectedSignature),
                Convert.ToHexString(actualSignature)
            );
            return null;
        }

        logger.LogDebug("Webhook event was found to be correctly signed");

        return evnt;
    }

    private async Task<(T? Value, byte[] Signature)> DeserializeWithSignatureAsync<T>(
        Stream utf8Stream,
        CancellationToken cancellationToken = default
    )
    {
        using var lease = await utf8Stream.ReadToMemoryAsync(cancellationToken);
        var signature = HMACSHA256.HashData(_secret, lease.Memory.Span);
        var value = JsonSerializer.Deserialize<T>(
            lease.Memory.Span,
            AkilesApiJsonSerializerOptions.Value
        );
        return (value, signature);
    }
}
