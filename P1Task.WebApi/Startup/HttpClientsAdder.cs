using P1Task.SecclConnector;

namespace P1Task.WebApi.Startup;

public static class HttpClientsAdder
{
    public static void AddHttpClients(this WebApplicationBuilder builder, string webApiBaseAddress)
    {
        builder.Services.AddHttpClient<ITokenHttpClient, TokenHttpClient>(client =>
        {
            client.BaseAddress = new Uri(webApiBaseAddress);
        });

        builder.Services.AddHttpClient<IPortfolioSummaryHttpClient, PortfolioSummaryHttpClient>(client =>
        {
            client.BaseAddress = new Uri(webApiBaseAddress);
        });
    }
}
