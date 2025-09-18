// Used https://json2csharp.com/ to generate C# classes from JSON. (Only used relevant properties of the generated classes.)

namespace P1Task.Dtos;

public record Account
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string AccountType { get; set; }
    public required double CurrentValue { get; set; }
}
