using EquipmentRental.Repository.Presistance;

namespace EquipmentRental.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEquipementRepository EquipementRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }

        public UnitOfWork(IEquipmentDbContext context)
        {
            EquipementRepository = new EquipmentRepository(context);
            OrderRepository = new OrderRepository(context);
            CustomerRepository = new CustomerRepository(context);
        }
    }
}
