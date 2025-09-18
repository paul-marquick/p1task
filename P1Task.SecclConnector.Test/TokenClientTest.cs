namespace P1Task.SecclConnector.Test;

public class TokenClientTest
{
    private const string firmId = "P1IMX";
    private const string id = "nelahi6642@4tmail.net";
    private const string password = "DemoBDM1";

    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://pfolio-api-staging.seccl.tech/")
    };

    [Fact]
    public async Task GetTokenAsyncTest()
    {
        ITokenClient tokenClient = new TokenClient(_httpClient);
        string token = await tokenClient.GetTokenAsync(firmId, id, password);

        Assert.NotEmpty(token);
    }
}
