namespace Akiles.ApiClient.Tests;

public class PagedListTests
{
    public void CanCreate_FromCollectionExpression()
    {
        PagedList<int> list = [1, 2, 3];
        Assert.Equal(3, list.Data.Count);
    }
}
