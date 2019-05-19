using EquipmentRental.Domain.EquipmentTypes;
using EquipmentRental.Domain.Models;
using System.Collections.Generic;

namespace EquipmentRental.Repository.Persistence
{
    public class EquipmentDbContext : IEquipmentDbContext
    {
        public IList<Equipment> Equipments { get; set; }
        public IList<Order> Orders { get; set; }
        public IList<Customer> Customers { get; set; }

        public EquipmentDbContext()
        {
            Equipments = new List<Equipment>
            {
                new Equipment(1, "Caterpillar bulldozer", new HeavyEquipment()),
                new Equipment(2, "KamAZ truck", new RegularEquipment()),
                new Equipment(3, "Komatsu crane", new HeavyEquipment()),
                new Equipment(4, "Volvo steamroller", new RegularEquipment()),
                new Equipment(5, "Bosch jackhammer", new SpecializedEquipment()),
            };

            Orders = new List<Order>();
            Customers = new List<Customer>
            {
                new Customer{ Id = 1, Name = "Jhon", Email = "jhon@email.com", Password = "test#21" }
            };
        }
    }
}
