using Akiles.ApiClient.Members;

namespace Akiles.ApiClient.Tests;

public class SortTests
{
    [Fact]
    public void CreatesCorrectSortString()
    {
        Assert.Equal("created_at:desc", new Sort<Member>(x => x.CreatedAt, SortOrder.Desc));
        Assert.Equal(
            "metadata.source:desc",
            new Sort<Member>(x => x.Metadata["source"], SortOrder.Desc)
        );

        Assert.Equal(
            "metadata.source:desc",
            new Sort<Member>(x => x.Metadata[SourceMetadataKey], SortOrder.Desc)
        );

        var sourceMetadataKey = "source";
        Assert.Throws<NotSupportedException>(
            () => new Sort<Member>(x => x.Metadata[sourceMetadataKey], SortOrder.Desc)
        );
    }

    private const string SourceMetadataKey = "source";
}
