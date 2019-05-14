namespace EquipmentRental.Domain.EquipmentTypes
{
    public interface IEquipmentType
    {
        string Name { get; set; }
        double GetPrice(int daysOfRent);
    }
}
