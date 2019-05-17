using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository.Presistance;

namespace EquipmentRental.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext context;

        public OrderRepository(IDbContext context)
        {
            this.context = context;
        }
        public void Add(Order order)
        {
            context.Orders.Add(order);
        }

        public IList<Order> GetAll()
        {
            return context.Orders.ToList();
        }
    }
}
