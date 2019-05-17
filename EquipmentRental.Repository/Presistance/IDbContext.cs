using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository.Presistance
{
    public interface IDbContext
    {
        IList<Equipment> Equipments { get; set; }
    }
}
