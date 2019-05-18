using System.Collections.Generic;
using EquipmentRental.Domain.Models;

namespace EquipmentRental.Repository
{
    public interface IOrderRepository
    {
        IList<Order> Get(int customerId);
        void Add(Order order);
        IList<Order> GetByCustomer(int customerId);
    }
}
