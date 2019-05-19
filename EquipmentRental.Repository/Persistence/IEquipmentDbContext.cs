using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository.Persistence
{
    public interface IEquipmentDbContext
    {
        IList<Equipment> Equipments { get; set; }
        IList<Order> Orders { get; set; }
        IList<Customer> Customers { get; set; }
    }
}
