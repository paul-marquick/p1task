using P1Task.Models;

namespace P1Task.Aggregator;

public interface ITotalsAggregator
{
    Totals AggregateTotals(List<PortfolioSummary> portfolioSummaries);
}
