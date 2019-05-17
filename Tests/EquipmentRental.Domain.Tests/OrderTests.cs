using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Domain.Models;
using Xunit;

namespace EquipmentRental.Domain.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Constractor_WithTitleTypeRentOfdaysParams_ShouldAssign_PassedProperties()
        {
            var order = new Order("Eq 1", new HeavyEquipement(), 1);

            Assert.Equal("Eq 1", order.Equipment.Title);
            Assert.Equal(1, order.RentOfDays);
            Assert.Equal(typeof(HeavyEquipement), order.Equipment.EquipmentType.GetType());
        }

        [Fact]
        public void Constractor_WithTitleTypeParams_ShouldAssign_PassedProperties()
        {
            var order = new Order("Eq 1", new RegularEquipment());
            
            Assert.Equal("Eq 1", order.Equipment.Title);
            Assert.Equal(0, order.RentOfDays);
            Assert.Equal(typeof(RegularEquipment), order.Equipment.EquipmentType.GetType());
            
        }

        [Fact]
        public void Constractor_WithEquipmentParams_ShouldAssign_PassedProperties()
        {
            var order = new Order(new Equipment("Eq 2", new SpecializedEquipement()));
            
            Assert.Equal("Eq 2", order.Equipment.Title);
            Assert.Equal(0, order.RentOfDays);
            Assert.Equal(typeof(SpecializedEquipement), order.Equipment.EquipmentType.GetType());
        }

        [Fact]
        public void Constractor_WithEquipmentRentOfDaysParams_ShouldAssign_PassedProperties()
        {
            var order = new Order(new Equipment("Eq 2", new SpecializedEquipement()), 2);

            Assert.Equal("Eq 2", order.Equipment.Title);
            Assert.Equal(2, order.RentOfDays);
            Assert.Equal(typeof(SpecializedEquipement), order.Equipment.EquipmentType.GetType());
        }

    }
}
