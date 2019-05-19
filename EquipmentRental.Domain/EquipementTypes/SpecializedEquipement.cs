using EquipmentRental.Domain.EquipmentTypes;
using RentalFee = EquipmentRental.Domain.Constants.RentalFee;

namespace EquipmentRental.Domain.EquipementTypes
{
    public class SpecializedEquipement : IEquipmentType
    {
        private const int NumberOfDaysForPrimumFee = 3;

        public int LoyalityPoint => 1;

        public string Name => "Specialized";

        public double GetPrice(int daysOfRent)
        {
            var preimumFee = daysOfRent > NumberOfDaysForPrimumFee ? RentalFee.PremiumDailyFee * NumberOfDaysForPrimumFee : RentalFee.PremiumDailyFee * daysOfRent;
            var regularFee = daysOfRent > NumberOfDaysForPrimumFee ? RentalFee.RegularDailyFee * (daysOfRent - NumberOfDaysForPrimumFee) : 0;
            return preimumFee + regularFee;
        }
    }
}
