namespace EquipmentRental.Domain.Resources
{
    public class OrderResultResource : EquipmentResource
    {
        public int RentOfDays { get; set; }
        public double Price { get; set; }
    }
}
