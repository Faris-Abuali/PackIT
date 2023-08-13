namespace PackIT.Domain.Entities;

public record Localization(string City, string Country)
{
    // Conversion from string into Value Object
    public static Localization Create(string value)
    {
        var splitLocalization = value.Split(",");
        return new Localization(splitLocalization.First(), splitLocalization.Last());
    }

    // Conversion from Value Object into string
    public override string ToString()
        => $"{City}, {Country}";
}