using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository
{
    public class EquipmentRepository : IEquipementRepository
    {
        public IList<Equipment> Equipements { get; set; }

        public EquipmentRepository()
        {
            
        }
        public EquipmentRepository(IList<Equipment> equipements)
        {
            Equipements = equipements;
        }

        public IList<Equipment> GetAll()
        {
            return Equipements;
        }
    }
}
