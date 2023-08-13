using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

public record PackingItem
{
    public string Name { get; }
    public uint Quantity { get; }
    public bool IsPacked { get; init; }
    // init means that the property is still immutable of course, but it can be initialized inside the constructor or in object initializer like we did in `PackItem` method in `PackingList` entity. 

    public PackingItem(string name, uint quantity, bool isPacked = false)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptyPackingListItemNameException();
        }
        
        Name = name;
        Quantity = quantity;
        IsPacked = isPacked;
    }
}