// Used https://json2csharp.com/ to generate C# classes from JSON. (Only used relevant properties of the generated classes.)


namespace P1Task.Dtos;

public record ProfolioSummary
{
    public required List<Account> Accounts { get; set; }
}
