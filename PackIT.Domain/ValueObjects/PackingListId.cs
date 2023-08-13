using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

public record PackingListId
{
    public Guid Value { get; }

    public PackingListId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyPackingListIdException();
        }

        Value = value;
    }
    
    // Conversion from Value Object into Guid
    public static implicit operator Guid(PackingListId id)
        => id.Value;
    
    // Conversion from Guid into Value Object
    public static implicit operator PackingListId(Guid id)
        => new(id);
}