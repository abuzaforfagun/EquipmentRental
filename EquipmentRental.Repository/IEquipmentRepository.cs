using EquipmentRental.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.Repository
{
    public interface IEquipmentRepository
    {
        IList<Equipment> GetAll();
        Equipment Get(int id);
        Task<IList<Equipment>> GetAllAsync();
        Task<Equipment> GetAsync(int id);

    }
}
