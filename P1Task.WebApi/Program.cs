using Microsoft.Extensions.Caching.Memory;
using P1Task.Aggregator;
using P1Task.Models;
using P1Task.SecclConnector;
using P1Task.WebApi.Startup;

const string memoryCacheTokenKey = "token";
const string allowAllCorsName = "AllowAll";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMemoryCache();
var config = builder.GetConfig();
builder.AddHttpClients(config.SecclApiBaseAddress);
builder.Services.AddSingleton<ITotalsAggregator, TotalsAggregator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllCorsName,
        policy =>
        {
            policy.AllowAnyOrigin() 
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("*");
        });
});

var app = builder.Build();

app.UseCors(allowAllCorsName);

// Configure the HTTP request pipeline.

app.MapGet("/totals", async (
    IMemoryCache memoryCache, 
    ITokenHttpClient tokenHttpClient, 
    IPortfolioSummaryHttpClient portfolioSummaryHttpClient, 
    ITotalsAggregator totalsAggregator) =>
{
    // Get token from memory cache or get a new one from token client.

    if (!memoryCache.TryGetValue(memoryCacheTokenKey, out string? token))
    {
        // Token not found in memory cache, get a new one from token client.
        token = await tokenHttpClient.GetTokenAsync(config.SecclFirmId, config.SecclId, config.SecclPassword); 
        
        // Store the new access token in memory cache.
        memoryCache.Set(memoryCacheTokenKey, token);
    }

    // Get portfolio summaries from portfolio summary client.

    // 00GG5G2 - Mr Joe Bloggs.
    // 033D9GG - Mr Joe Terry.
    // C069J8P - Corry Bloggs.

    List<PortfolioSummary> portfolioSummaries = [];
    portfolioSummaries.Add(await portfolioSummaryHttpClient.GetPortfolioSummaryAsync(token!, config.SecclFirmId, "00GG5G2"));
    portfolioSummaries.Add(await portfolioSummaryHttpClient.GetPortfolioSummaryAsync(token!, config.SecclFirmId, "033D9GG"));
    portfolioSummaries.Add(await portfolioSummaryHttpClient.GetPortfolioSummaryAsync(token!, config.SecclFirmId, "C069J8P"));

    // get totals from totals aggregator.
    Totals totals = totalsAggregator.AggregateTotals(portfolioSummaries);

    return totals;
});

app.Run();
