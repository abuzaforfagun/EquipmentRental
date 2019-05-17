using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository.Presistance
{
    public class DbContext : IDbContext
    {
        public IList<Equipment> Equipments { get; set; }
        public IList<Order> Orders { get; set; }

        public DbContext()
        {
            Equipments = new List<Equipment>
            {
                new Equipment(1, "Caterpillar bulldozer", new HeavyEquipement()),
                new Equipment(2, "KamAZ truck", new RegularEquipment()),
                new Equipment(3, "Komatsu crane", new HeavyEquipement()),
                new Equipment(4, "Volvo steamroller", new RegularEquipment()),
                new Equipment(5, "Bosch jackhammer", new SpecializedEquipement()),
            };

            Orders = new List<Order>();
        }
    }
}
