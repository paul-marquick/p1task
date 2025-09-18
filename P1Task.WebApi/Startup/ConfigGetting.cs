namespace P1Task.WebApi.Startup;

public static class ConfigGetting
{
    public static Config GetConfig(this WebApplicationBuilder builder)
    {
        IConfigurationSection configurationSection = builder.Configuration.GetSection("Config");
        builder.Services.Configure<Config>(configurationSection);

        return configurationSection.Get<Config>()!;
    }
}
