using P1Task.Models;
using System.Text.Json;

namespace P1Task.SecclConnector;

public class PortfolioSummaryHttpClient(HttpClient httpClient) : IPortfolioSummaryHttpClient
{
    public async Task<PortfolioSummary> GetPortfolioSummaryAsync(string token, string firmId, string clientId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"portfolio/summary/{firmId}/{clientId}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        using HttpResponseMessage response = await httpClient.SendAsync(request);
        
        var portfolioSummaryResponse = JsonSerializer.Deserialize<PortfolioSummaryResponse>(await response.Content.ReadAsStringAsync(), JsonSerializerOptions.Web)!;

        return portfolioSummaryResponse.Data;
    }

    private record PortfolioSummaryResponse
    {
        public required PortfolioSummary Data { get; set; }
    }
}
