namespace P1Task.WebApi;

public record Config
{
    public required string SecclApiBaseAddress { get; set; }
    public required string SecclFirmId { get; set; }
    public required string SecclId { get; set; }
    public required string SecclPassword { get; set; }
}
