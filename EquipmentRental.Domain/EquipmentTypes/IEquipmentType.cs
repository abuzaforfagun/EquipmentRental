namespace EquipmentRental.Domain.EquipmentTypes
{
    public interface IEquipmentType
    {
        int LoyaltyPoint { get; }
        string Name { get; }
        double GetPrice(int daysOfRent);
    }
}
