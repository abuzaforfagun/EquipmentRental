using RentalFee = EquipmentRental.Domain.Constants.RentalFee;

namespace EquipmentRental.Domain.EquipmentTypes
{
    public class RegularEquipment : IEquipmentType
    {
        private const int NumberOfDaysForPremiumFee = 2;
        public string Name => "Regular";

        public int LoyaltyPoint => 1;

        public double GetPrice(int daysOfRent)
        {
            var premiumFee = daysOfRent > NumberOfDaysForPremiumFee ? RentalFee.PremiumDailyFee * NumberOfDaysForPremiumFee : RentalFee.PremiumDailyFee * daysOfRent;
            var regularFee = daysOfRent > NumberOfDaysForPremiumFee ? RentalFee.RegularDailyFee * (daysOfRent - NumberOfDaysForPremiumFee) : 0;

            return RentalFee.OneTimeRentalFee + premiumFee + regularFee;
        }
    }
}
