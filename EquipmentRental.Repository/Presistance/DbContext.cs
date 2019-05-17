using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository.Presistance
{
    public class DbContext : IDbContext
    {
        public IList<Equipment> Equipments { get; set; }

        public DbContext()
        {
            Equipments = new List<Equipment>
            {
                new Equipment("Caterpillar bulldozer", new HeavyEquipement()),
                new Equipment("KamAZ truck", new RegularEquipment()),
                new Equipment("Komatsu crane", new HeavyEquipement()),
                new Equipment("Volvo steamroller", new RegularEquipment()),
                new Equipment("Bosch jackhammer", new SpecializedEquipement()),
            };
        }
    }
}
