using System.Text.Json;
using Akiles.ApiClient.Members;

namespace Akiles.ApiClient.Tests;

public class JsonSerializerTests
{
    [Fact]
    public void CorrectlySerializesOptionType()
    {
        // Given
        var patch = new MemberPatch() { Name = "Assigned Name" };

        // When
        var json = JsonSerializer.Serialize(patch, AkilesApiJsonSerializerOptions.Value);

        // Then
        Assert.Equal("""{"name":"Assigned Name"}""", json);
    }
}
