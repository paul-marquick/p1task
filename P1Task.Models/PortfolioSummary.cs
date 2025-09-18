// Used https://json2csharp.com/ to generate C# classes from JSON. (Only used relevant properties of the generated classes.)

namespace P1Task.Models;

public record PortfolioSummary
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required List<Account> Accounts { get; set; }
    public required decimal CurrentValue { get; set; }
}
