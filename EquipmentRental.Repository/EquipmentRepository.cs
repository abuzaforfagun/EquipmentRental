using System.Collections.Generic;

namespace EquipmentRental.Repository
{
    public class EquipmentRepository : IEquipementRepository
    {
        public IList<string> Equipements { get; set; }

        public EquipmentRepository()
        {
            
        }
        public EquipmentRepository(IList<string> equipements)
        {
            Equipements = equipements;
        }

        public IList<string> GetAll()
        {
            return Equipements;
        }
    }
}
