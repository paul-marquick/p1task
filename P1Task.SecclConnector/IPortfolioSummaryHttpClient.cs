using P1Task.Models;

namespace P1Task.SecclConnector;

public interface IPortfolioSummaryHttpClient
{
    Task<PortfolioSummary> GetPortfolioSummaryAsync(string token, string firmId, string clientId);
}
