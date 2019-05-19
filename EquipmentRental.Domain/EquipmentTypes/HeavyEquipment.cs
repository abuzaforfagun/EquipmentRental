namespace EquipmentRental.Domain.EquipmentTypes
{
    public class HeavyEquipment : IEquipmentType
    {
        public int LoyaltyPoint => 2;

        public string Name => "Heavy";

        public double GetPrice(int daysOfRent)
        {
            return Constants.RentalFee.OneTimeRentalFee + (Constants.RentalFee.PremiumDailyFee * daysOfRent);
        }
    }
}
