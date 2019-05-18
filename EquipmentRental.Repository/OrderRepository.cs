using System.Collections.Generic;
using System.Linq;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository.Presistance;

namespace EquipmentRental.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IEquipmentDbContext context;

        public OrderRepository(IEquipmentDbContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);
        }

        public IList<Order> Get(int customerId)
        {
            return context.Orders.Where(o => o.Customer.Id == customerId).ToList();
        }

        public IList<Order> GetByCustomer(int customerId)
        {
            return context.Orders.Where(o => o.Customer.Id == customerId).ToList();
        }
    }
}
