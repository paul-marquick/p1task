using P1Task.Models;

namespace P1Task.Aggregator;

/// <summary>
/// Calculates aggregated totals from a list of portfolio summaries.
/// </summary>
public interface ITotalsAggregator
{
    /// <summary>
    /// Sums up the totals from multiple portfolio summaries.
    /// </summary>
    /// <param name="portfolioSummaries"></param>
    /// <returns></returns>
    Totals AggregateTotals(List<PortfolioSummary> portfolioSummaries);
}
