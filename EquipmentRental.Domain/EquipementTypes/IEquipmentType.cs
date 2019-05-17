namespace EquipmentRental.Domain.EquipmentTypes
{
    public interface IEquipmentType
    {
        int LoyalityPoint { get; }
        string Name { get; }
        double GetPrice(int daysOfRent);
    }
}
