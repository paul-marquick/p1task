using P1Task.Models;
using System.Text.Json;

namespace P1Task.WebApp.HttpClients;

public class TotalsHttpClient(HttpClient httpClient) : ITotalsHttpClient
{
    public async Task<Totals> GetTotalsAsync()
    {
        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "totals");

        using HttpResponseMessage response = await httpClient.SendAsync(request);

        return JsonSerializer.Deserialize<Totals>(await response.Content.ReadAsStringAsync(), JsonSerializerOptions.Web)!;
    }
}
