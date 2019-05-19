namespace EquipmentRental.Repository
{
    public interface IUnitOfWork
    {
        IEquipmentRepository EquipmentRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }

        ICustomerRepository CustomerRepository { get; set; }
        
    }
}