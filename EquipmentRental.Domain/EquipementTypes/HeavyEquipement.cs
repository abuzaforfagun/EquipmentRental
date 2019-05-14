using EquipmentRental.Domain.EquipmentTypes;

namespace EquipmentRental.Domain.EquipementTypes
{
    public class HeavyEquipement : IEquipmentType
    {
        public string Name { get; set; }

        public double GetPrice(int daysOfRent)
        {
            return Constants.RentalFee.OneTimeRentalFee + (Constants.RentalFee.PremiumDailyFee * daysOfRent);
        }
    }
}
