namespace P1Task.WebApi;

public record Secrets
{
    public required string SecclFirmId { get; set; }
    public required string SecclId { get; set; }
    public required string SecclPassword { get; set; }
}
