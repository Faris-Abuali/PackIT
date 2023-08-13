using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies;

public record PolicyData(TravelDays Days, Constants.Gender Gender, ValueObjects.Temperature Temperature, 
    Localization Localization);