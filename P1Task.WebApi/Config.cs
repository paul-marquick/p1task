namespace P1Task.WebApi;

/// <summary>
/// Holds configuration settings for the web api. That don't need to be secret.
/// </summary>
public record Config
{
    public required string SecclApiBaseAddress { get; set; }
}
