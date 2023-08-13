using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal sealed class FemaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Gender is Constants.Gender.Female;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        => new List<PackingItem>
        {
            new("Lipstick", 1),
            new("Powder", 1),
            new("Eyeliner", 1)
        };
}