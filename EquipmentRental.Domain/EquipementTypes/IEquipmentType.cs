namespace EquipmentRental.Domain.EquipmentTypes
{
    public interface IEquipmentType
    {
        int LoyalityPoint { get; }
        string Name { get; set; }
        double GetPrice(int daysOfRent);
    }
}
