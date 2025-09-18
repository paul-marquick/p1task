namespace P1Task.WebApi;

/// <summary>
/// Holds secret configuration settings for the web api.
/// </summary>
public record Secrets
{
    public required string SecclFirmId { get; set; }
    public required string SecclId { get; set; }
    public required string SecclPassword { get; set; }
}
