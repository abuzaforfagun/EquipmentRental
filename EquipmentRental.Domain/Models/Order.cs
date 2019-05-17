using EquipmentRental.Domain.EquipmentTypes;

namespace EquipmentRental.Domain.Models
{
    public class Order
    {
        public Equipment Equipment { get; set; }
        public int RentOfDays { get; set; }

        public Order(string title, IEquipmentType equipmentType, int rentOfDays)
        {
            Equipment = new Equipment()
            {
                Title = title,
                EquipmentType = equipmentType
            };
            RentOfDays = rentOfDays;
        }

        public Order(string title, IEquipmentType equipmentType)
        {
            Equipment = new Equipment()
            {
                Title = title,
                EquipmentType = equipmentType
            };
        }

        public Order(Equipment equipment)
        {
            Equipment = equipment;
        }

        public Order(Equipment equipment, int rentOfDays)
        {
            Equipment = equipment;
            RentOfDays = rentOfDays;
        }

        public double GetPrice()
        {
            return Equipment.EquipmentType.GetPrice(RentOfDays);
        }
    }
}
