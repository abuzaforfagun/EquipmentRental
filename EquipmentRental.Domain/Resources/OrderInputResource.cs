namespace EquipmentRental.Domain.Resources
{
    public class OrderInputResource
    {
        public int EquipmentId { get; set; }
        public int DaysOfRent { get; set; }
        public int CustomerId { get; set; }
    }
}
