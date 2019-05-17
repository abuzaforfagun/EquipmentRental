using EquipmentRental.Domain.Models;

namespace EquipmentRental.Repository
{
    public interface ICustomerRepository
    {
        Customer Get(int id);
    }
}
