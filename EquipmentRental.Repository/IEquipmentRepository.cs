using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository
{
    public interface IEquipmentRepository
    {
        IList<Equipment> GetAll();
        Equipment Get(int id);
    }
}
