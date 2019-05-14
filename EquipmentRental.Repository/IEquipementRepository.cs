using System.Collections.Generic;

namespace EquipmentRental.Repository
{
    public interface IEquipementRepository
    {
        IList<string> Equipements { get; set; }
        IList<string> GetAll();
    }
}
