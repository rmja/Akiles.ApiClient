using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Akiles.ApiClient;

public static class AkilesApiExtensions
{
    public static IServiceCollection AddAkilesApiClient(
        this IServiceCollection services,
        Action<AkilesApiOptions>? configureOptions = null
    )
    {
        services.AddHttpClient<AkilesApiClient>();

        services.TryAddSingleton<IAkilesApiClientFactory, AkilesApiClientFactory>();

        if (configureOptions is not null)
        {
            services.TryAddTransient<IAkilesApiClient>(provider =>
            {
                var httpClient = provider
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient(nameof(AkilesApiClient));
                var options = provider.GetRequiredService<IOptions<AkilesApiOptions>>();
                var apiKey =
                    options.Value.ApiKey
                    ?? throw new InvalidOperationException(
                        "No API key configured. Use IAkilesApiClientFactory instead to create a client from an access token"
                    );
                return new AkilesApiClient(httpClient, apiKey);
            });

            services.Configure(configureOptions);
        }

        return services;
    }
}
