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
        public void Constractor_WithEquipmentCustomerRentOfDaysParams_ShouldAssign_PassedProperties()
        {
            var order = new Order(new Equipment(2, "Eq 2", new SpecializedEquipement()), 
                new Customer{Email = "email@em.com", Id=1, Name = "abc", Password = "123"}, 2);

            Assert.Equal("Eq 2", order.Equipment.Title);
            Assert.Equal("email@em.com", order.Customer.Email);
            Assert.Equal(2, order.RentOfDays);
            Assert.Equal(typeof(SpecializedEquipement), order.Equipment.EquipmentType.GetType());
        }
    }
}
