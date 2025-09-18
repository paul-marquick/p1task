namespace P1Task.SecclConnector.Test;

public class TokenHttpClientTest : HttpClientTestBase
{
    [Fact]
    public async Task GetTokenAsyncTest()
    {
        string token = await tokenClient.GetTokenAsync(firmId, id, password);

        Assert.NotEmpty(token);
    }
}
