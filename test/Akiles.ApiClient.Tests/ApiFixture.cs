using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Akiles.ApiClient.Tests;

public class ApiFixture
{
    public IAkilesApiClient Client { get; }

    public ApiFixture()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<ApiFixture>().Build();
        var services = new ServiceCollection()
            .AddAkilesApiClient(options =>
            {
                options.ApiKey = config["AkilesApiKey"];
            })
            .BuildServiceProvider();
        Client = services.GetRequiredService<IAkilesApiClient>();
    }
}
