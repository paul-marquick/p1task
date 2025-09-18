using P1Task.Dtos;
using System.Text.Json;

namespace P1Task.SecclConnector;

public class AccountClient(HttpClient httpClient) : IAccountClient
{
    public async Task<List<Account>> GetAccountsAsync(string token, string firmId, string clientId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"portfolio/summary/{firmId}/{clientId}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        using HttpResponseMessage response = await httpClient.SendAsync(request);
        
        var portfolioSummaryResponse = JsonSerializer.Deserialize<PortfolioSummaryResponse>(await response.Content.ReadAsStringAsync(), JsonSerializerOptions.Web)!;

        return portfolioSummaryResponse.Data.Accounts;
    }

    private record PortfolioSummaryResponse
    {
        public required Data Data { get; set; }
    }

    private record Data
    {
        public required List<Account> Accounts { get; set; }
    }
}
