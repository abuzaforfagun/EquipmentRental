using RentalFee = EquipmentRental.Domain.Constants.RentalFee;

namespace EquipmentRental.Domain.EquipmentTypes
{
    public class SpecializedEquipment : IEquipmentType
    {
        private const int NumberOfDaysForPremiumFee = 3;

        public int LoyaltyPoint => 1;

        public string Name => "Specialized";

        public double GetPrice(int daysOfRent)
        {
            var premiumFee = daysOfRent > NumberOfDaysForPremiumFee ? RentalFee.PremiumDailyFee * NumberOfDaysForPremiumFee : RentalFee.PremiumDailyFee * daysOfRent;
            var regularFee = daysOfRent > NumberOfDaysForPremiumFee ? RentalFee.RegularDailyFee * (daysOfRent - NumberOfDaysForPremiumFee) : 0;
            return premiumFee + regularFee;
        }
    }
}
