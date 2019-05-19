using EquipmentRental.Repository.Persistence;

namespace EquipmentRental.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEquipmentRepository EquipmentRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }

        public UnitOfWork(IEquipmentDbContext context)
        {
            EquipmentRepository = new EquipmentRepository(context);
            OrderRepository = new OrderRepository(context);
            CustomerRepository = new CustomerRepository(context);
        }
    }
}
