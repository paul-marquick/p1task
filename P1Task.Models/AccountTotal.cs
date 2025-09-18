// Used https://json2csharp.com/ to generate C# classes from JSON. (Only used relevant properties of the generated classes.)

namespace P1Task.Models;

public record AccountTotal
{
    public required string AccountType { get; set; }
    public required decimal Total { get; set; }
}
