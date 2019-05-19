using EquipmentRental.Domain.EquipmentTypes;
using EquipmentRental.Domain.Models;
using Xunit;

namespace EquipmentRental.Domain.Tests
{
    public class OrderTests
    {

        [Fact]
        public void Constructor_WithEquipmentParams_ShouldAssign_PassedProperties()
        {
            var order = new Order(new Equipment(1, "Eq 2", new SpecializedEquipment()));
            
            Assert.Equal("Eq 2", order.Equipment.Title);
            Assert.Equal(0, order.RentOfDays);
            Assert.Equal(typeof(SpecializedEquipment), order.Equipment.EquipmentType.GetType());
        }

        [Fact]
        public void Constructor_WithEquipmentCustomerRentOfDaysParams_ShouldAssign_PassedProperties()
        {
            var order = new Order(new Equipment(2, "Eq 2", new SpecializedEquipment()), 
                new Customer{Email = "email@em.com", Id=1, Name = "abc", Password = "123"}, 2);

            Assert.Equal("Eq 2", order.Equipment.Title);
            Assert.Equal("email@em.com", order.Customer.Email);
            Assert.Equal(2, order.RentOfDays);
            Assert.Equal(typeof(SpecializedEquipment), order.Equipment.EquipmentType.GetType());
        }
    }
}
