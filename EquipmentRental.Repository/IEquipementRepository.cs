using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository
{
    public interface IEquipementRepository
    {
        IList<Equipment> Equipements { get; set; }
        IList<Equipment> GetAll();
    }
}
