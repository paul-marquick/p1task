using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using P1Task.WebApp;
using P1Task.WebApp.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<ITotalsHttpClient, TotalsHttpClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5105");
});

await builder.Build().RunAsync();
