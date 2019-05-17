namespace EquipmentRental.Domain.Models
{
    public class Order
    {
        public Equipment Equipment { get; set; }
        public int RentOfDays { get; set; }
        public double Price { get; }

        public Order(Equipment equipment)
        {
            Equipment = equipment;
        }

        public Order(Equipment equipment, int rentOfDays)
        {
            Equipment = equipment;
            RentOfDays = rentOfDays;
            Price = GetPrice();
        }
        

        public double GetPrice()
        {
            return Equipment.EquipmentType.GetPrice(RentOfDays);
        }
    }
}
