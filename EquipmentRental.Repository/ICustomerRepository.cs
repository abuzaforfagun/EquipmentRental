using System.Threading.Tasks;
using EquipmentRental.Domain.Models;

namespace EquipmentRental.Repository
{
    public interface ICustomerRepository
    {
        Customer Get(int id);
        Customer Get(string email, string password);
        Task<Customer> GetAsync(int id);
        Task<Customer> GetAsync(string email, string password);
    }
}
