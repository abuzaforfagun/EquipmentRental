using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository.Persistence;

namespace EquipmentRental.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IEquipmentDbContext _context;

        public OrderRepository(IEquipmentDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public IList<Order> Get(int customerId)
        {
            return _context.Orders.Where(o => o.Customer.Id == customerId).ToList();
        }

        public IList<Order> GetByCustomer(int customerId)
        {
            return _context.Orders.Where(o => o.Customer.Id == customerId).ToList();
        }

        public async Task<IList<Order>> GetAsync(int customerId)
        {
            var task = Task.Run(() => _context.Orders.Where(o => o.Customer.Id == customerId).ToList());
            return await task;
        }

        public void AddAsync(Order order)
        {
            Task.Run(() => _context.Orders.Add(order));
        }

        public async Task<IList<Order>> GetByCustomerAsync(int customerId)
        {
            var task = Task.Run(() => _context.Orders.Where(o => o.Customer.Id == customerId).ToList());
            return await task;
        }
    }
}
