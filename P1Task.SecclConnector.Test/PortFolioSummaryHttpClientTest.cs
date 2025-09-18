using P1Task.Models;

namespace P1Task.SecclConnector.Test;

public class PortFolioSummaryHttpClientTest : HttpClientTestBase
{
    private const string clientId = "00GG5G2";

    [Fact]
    public async Task GetPortFolioAsyncTest()
    {
        string token = await tokenClient.GetTokenAsync(firmId, id, password);

        IPortfolioSummaryHttpClient portfolioSummaryClient = new PortfolioSummaryHttpClient(_httpClient);
        PortfolioSummary portfolioSummary = await portfolioSummaryClient.GetPortfolioSummaryAsync(token, firmId, clientId);

        Assert.NotEmpty(portfolioSummary.Id);
        Assert.NotEmpty(portfolioSummary.Name);
        Assert.NotEmpty(portfolioSummary.Accounts);
        Assert.True(portfolioSummary.Accounts.Count > 0);
    }
}
