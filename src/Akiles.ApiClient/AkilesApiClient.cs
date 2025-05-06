using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using Akiles.ApiClient.Cards;
using Akiles.ApiClient.Devices;
using Akiles.ApiClient.Events;
using Akiles.ApiClient.Gadgets;
using Akiles.ApiClient.MemberGroups;
using Akiles.ApiClient.Members;
using Akiles.ApiClient.Schedules;
using Akiles.ApiClient.Webhooks;
using Refit;

namespace Akiles.ApiClient;

public class AkilesApiClient : IAkilesApiClient
{
    private static readonly RefitSettings _refitSettings =
        new()
        {
            ContentSerializer = new SystemTextJsonContentSerializer(
                AkilesApiJsonSerializerOptions.Value
            ),
            UrlParameterKeyFormatter = new ParameterKeyFormatter(),
            UrlParameterFormatter = new ParameterFormatter(),
            ExceptionFactory = async (response) =>
            {
                if (response.IsSuccessStatusCode)
                {
                    return null;
                }

                var error = await response.Content.ReadFromJsonAsync(
                    AkilesApiJsonSerializerContext.Default.ErrorResponse
                );

                return new AkilesApiException(error!.Message)
                {
                    RequestUri = response.RequestMessage!.RequestUri!,
                    StatusCode = response.StatusCode,
                    ErrorType = error.Type,
                    ErrorArgs = error.Args,
                };
            }
        };

    public ICards Cards { get; }
    public IDevices Devices { get; }
    public IEvents Events { get; }
    public IGadgets Gadgets { get; }
    public IMembers Members { get; }
    public IMemberGroups MemberGroups { get; }
    public ISchedules Schedules { get; }
    public IWebhooks Webhooks { get; }

    public AkilesApiClient(HttpClient httpClient, string accessToken)
    {
        httpClient.BaseAddress ??= new("https://api.akiles.app/v2");
        httpClient.DefaultRequestHeaders.Authorization = new("Bearer", accessToken);

        Cards = RestService.For<ICards>(httpClient, _refitSettings);
        Devices = RestService.For<IDevices>(httpClient, _refitSettings);
        Events = RestService.For<IEvents>(httpClient, _refitSettings);
        Gadgets = RestService.For<IGadgets>(httpClient, _refitSettings);
        Members = RestService.For<IMembers>(httpClient, _refitSettings);
        MemberGroups = RestService.For<IMemberGroups>(httpClient, _refitSettings);
        Schedules = RestService.For<ISchedules>(httpClient, _refitSettings);
        Webhooks = RestService.For<IWebhooks>(httpClient, _refitSettings);
    }

    class ParameterKeyFormatter(JsonNamingPolicy namingPolicy) : IUrlParameterKeyFormatter
    {
        public ParameterKeyFormatter()
            : this(JsonNamingPolicy.SnakeCaseLower) { }

        public string Format(string key) => namingPolicy.ConvertName(key);
    }

    class ParameterFormatter() : IUrlParameterFormatter
    {
        public IUrlParameterFormatter Next { get; set; } = new DefaultUrlParameterFormatter();

        public string? Format(object? value, ICustomAttributeProvider attributeProvider, Type type)
        {
            var formatter = (IUrlParameterFormatter?)
                value
                    ?.GetType()
                    .GetCustomAttributes()
                    .FirstOrDefault(x => x is IUrlParameterFormatter);
            if (formatter is not null)
            {
                return formatter.Format(value, attributeProvider, type);
            }

            return Next.Format(value, attributeProvider, type);
        }
    }
}
