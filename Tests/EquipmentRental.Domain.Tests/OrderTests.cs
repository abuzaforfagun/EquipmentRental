using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Domain.Models;
using Xunit;

namespace EquipmentRental.Domain.Tests
{
    public class OrderTests
    {

        [Fact]
        public void Constractor_WithEquipmentParams_ShouldAssign_PassedProperties()
        {
            var order = new Order(new Equipment(1, "Eq 2", new SpecializedEquipement()));
            
            Assert.Equal("Eq 2", order.Equipment.Title);
            Assert.Equal(0, order.RentOfDays);
            Assert.Equal(typeof(SpecializedEquipement), order.Equipment.EquipmentType.GetType());
        }

        [Fact]
        public void Constractor_WithEquipmentRentOfDaysParams_ShouldAssign_PassedProperties()
        {
            var order = new Order(new Equipment(2, "Eq 2", new SpecializedEquipement()), 2);

            Assert.Equal("Eq 2", order.Equipment.Title);
            Assert.Equal(2, order.RentOfDays);
            Assert.Equal(typeof(SpecializedEquipement), order.Equipment.EquipmentType.GetType());
        }

    }
}
