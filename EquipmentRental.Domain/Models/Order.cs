namespace EquipmentRental.Domain.Models
{
    public class Order
    {

        public Equipment Equipment { get; set; }
        public Customer Customer { get; set; }
        public int RentOfDays { get; set; }
        public double Price { get; }

        public Order(Equipment equipment)
        {
            Equipment = equipment;
        }

        public Order(Equipment equipment, Customer customer, int rentOfDays)
        {
            Equipment = equipment;
            Customer = customer;
            RentOfDays = rentOfDays;
            Price = GetPrice();
        }
        

        public double GetPrice()
        {
            return Equipment.EquipmentType.GetPrice(RentOfDays);
        }
    }
}
