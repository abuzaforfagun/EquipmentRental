using System.Collections.Generic;
using System.Linq;
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
    }
}
