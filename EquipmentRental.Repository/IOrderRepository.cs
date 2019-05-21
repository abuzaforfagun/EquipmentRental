using System.Collections.Generic;
using System.Threading.Tasks;
using EquipmentRental.Domain.Models;

namespace EquipmentRental.Repository
{
    public interface IOrderRepository
    {
        IList<Order> Get(int customerId);
        void Add(Order order);
        IList<Order> GetByCustomer(int customerId);
        Task<IList<Order>> GetAsync(int customerId);
        void AddAsync(Order order);
        Task<IList<Order>> GetByCustomerAsync(int customerId);

    }
}
