using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

// Value objects are by nature immutable.
// Since C# v9, records are by default implementing IEquatable<> interface
public record PackingListName
{
    public string Value { get; }

    public PackingListName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyPackingListNameException();
        }
        
        Value = value;
    }

    // Conversion from Value Object into string
    public static implicit operator string(PackingListName name)
        => name.Value;
    
    // Conversion from string into Value Object
    public static implicit operator PackingListName(string name)
        => new(name);
}