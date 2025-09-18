using P1Task.Models;

namespace P1Task.Aggregator;

public class TotalsAggregator : ITotalsAggregator
{
    public Totals AggregateTotals(List<PortfolioSummary> portfolioSummaries)
    {
        return new Totals
        {
            Total = portfolioSummaries.Sum(x => x.CurrentValue),
            AccountTotals = portfolioSummaries
                .SelectMany(x => x.Accounts)
                .GroupBy(x => x.AccountType)
                .Select(g => new AccountTotal
                {
                    AccountType = g.Key,
                    Total = g.Sum(x => x.CurrentValue)
                })
                .ToList()
        };

    }
}
