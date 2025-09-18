using P1Task.Models;

namespace P1Task.WebApp.HttpClients;
public interface ITotalsHttpClient
{
    Task<Totals> GetTotalsAsync();
}