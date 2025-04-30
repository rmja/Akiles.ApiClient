using System.Net;
using System.Net.Http.Json;
using Akiles.ApiClient.Members;

namespace Akiles.ApiClient.Tests;

public class RefitConfigurationTests
{
    [Theory]
    [InlineData(MembersExpand.None, "")]
    [InlineData(
        MembersExpand.Cards | MembersExpand.GroupAssociations,
        "&expand=cards%2Cgroup_associations"
    )]
    public async Task CorrectlySerializesQueryStringParameters(
        MembersExpand expand,
        string expectedExpand
    )
    {
        // Given
        var fakeMessageHandler = new FakeMessageHandler(HttpStatusCode.OK, new PagedList<Member>());
        var httpClient = new HttpClient(fakeMessageHandler);
        var client = new AkilesApiClient(httpClient, "access-token");

        // When
        await client
            .Members.ListMembersAsync(
                "created_at:desc",
                new()
                {
                    Email = "email",
                    IsDeleted = IsDeleted.Any,
                    Metadata = new() { ["source"] = "hello" }
                },
                expand
            )
            .ToListAsync();

        // Then
        var request = Assert.Single(fakeMessageHandler.RequestMessages);
        Assert.Equal(
            "?limit=100&sort=created_at%3Adesc&is_deleted=any&email=email&metadata.source=hello"
                + expectedExpand,
            request.RequestUri?.Query
        );
    }

    class FakeMessageHandler(HttpStatusCode statusCode = HttpStatusCode.OK, object? content = null)
        : HttpMessageHandler
    {
        public List<HttpRequestMessage> RequestMessages { get; } = [];

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            RequestMessages.Add(request);
            return Task.FromResult(
                new HttpResponseMessage(statusCode)
                {
                    RequestMessage = request,
                    Content = JsonContent.Create(
                        content,
                        options: AkilesApiJsonSerializerOptions.Value
                    )
                }
            );
        }
    }
}
