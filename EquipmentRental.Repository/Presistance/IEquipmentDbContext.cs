using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository.Presistance
{
    public interface IEquipmentDbContext
    {
        IList<Equipment> Equipments { get; set; }
        IList<Order> Orders { get; set; }
        IList<Customer> Customers { get; set; }
    }
}
