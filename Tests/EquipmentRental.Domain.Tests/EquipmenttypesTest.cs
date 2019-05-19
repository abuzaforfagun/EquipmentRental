using EquipmentRental.Domain.EquipmentTypes;
using System.Collections.Generic;
using Xunit;

namespace EquipmentRental.Domain.Tests
{
    public class EquipmentTypesTest
    {
        [Theory]
        [MemberData(nameof(RegularEquipmentTestData))]
        public void RegularEquipment_GetPrice_ShouldReturn_CorrectValue(int daysOfRent, double expectedPrice)
        {
            var equipmentTypes = new RegularEquipment();
            var price = equipmentTypes.GetPrice(daysOfRent);

            Assert.Equal(expectedPrice, price);
        }

        [Theory]
        [MemberData(nameof(SpecializedEquipmentTestData))]
        public void SpecializedEquipment_GetPrice_ShouldReturn_CorrectValue(int daysOfRent, double expectedPrice)
        {
            var equipmentTypes = new SpecializedEquipment();
            var price = equipmentTypes.GetPrice(daysOfRent);

            Assert.Equal(expectedPrice, price);
        }

        [Theory]
        [MemberData(nameof(HeavyEquipmentTestData))]
        public void HeavyEquipment_GetPrice_ShouldReturn_CorrectValue(int daysOfRent, double expectedPrice)
        {
            var equipmentTypes = new HeavyEquipment();
            var price = equipmentTypes.GetPrice(daysOfRent);

            Assert.Equal(expectedPrice, price);
        }

        public static IEnumerable<object[]> RegularEquipmentTestData =>
            new List<object[]>
            {
                new object[] { 1, 160},
                new object[] { 2, 220 },
                new object[] { 3, 260 }
            };

        public static IEnumerable<object[]> SpecializedEquipmentTestData =>
            new List<object[]>
            {
                new object[] { 2, 120 },
                new object[] { 3, 180 },
                new object[] { 4, 220 }
            };

        public static IEnumerable<object[]> HeavyEquipmentTestData =>
            new List<object[]>
            {
                new object[] { 2, 220 },
                new object[] { 3, 280 }
            };
    }
}
