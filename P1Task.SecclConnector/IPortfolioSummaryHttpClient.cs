using P1Task.Models;

namespace P1Task.SecclConnector;

/// <summary>
/// Makes web requests to Seccl's Portfolio Summary endpoint.
/// </summary>
public interface IPortfolioSummaryHttpClient
{
    /// <summary>
    /// Gets the portfolio summary for a given firm and client.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="firmId"></param>
    /// <param name="clientId"></param>
    /// <returns></returns>
    Task<PortfolioSummary> GetPortfolioSummaryAsync(string token, string firmId, string clientId);
}
