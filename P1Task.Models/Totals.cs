// Used https://json2csharp.com/ to generate C# classes from JSON. (Only used relevant properties of the generated classes.)

namespace P1Task.Models;

public record Totals
{
    public decimal? Total { get; set; }
    public List<AccountTotal>? AccountTotals { get; set; }
}
