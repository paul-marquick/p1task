using P1Task.Dtos;

namespace P1Task.SecclConnector.Test;

public class AccountClientTest
{
    private const string firmId = "P1IMX";
    private const string id = "nelahi6642@4tmail.net";
    private const string password = "DemoBDM1";

    private const string clientId = "00GG5G2";

    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://pfolio-api-staging.seccl.tech/")
    };

    [Fact]
    public async Task GetAccountsAsyncTest()
    {
        ITokenClient tokenClient = new TokenClient(_httpClient);
        string token = await tokenClient.GetTokenAsync(firmId, id, password);

        IAccountClient accountClient = new AccountClient(_httpClient);
        List<Account> accounts = await accountClient.GetAccountsAsync(token, firmId, clientId);

        Assert.NotEmpty(accounts);
        Assert.True(accounts.Count > 0);
    }
}
