using System.Collections.Generic;
using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository.Presistance;

namespace EquipmentRental.Tests.Presistance
{
    public class InMemoryDbContext : EquipmentDbContext
    {
        public InMemoryDbContext()
        {
            Equipments = new List<Equipment>
            {
                new Equipment()
                {
                    Id = 1,
                    Title = "Caterpillar bulldozer",
                    EquipmentType = new HeavyEquipement()
                },
                new Equipment()
                {
                    Id = 2,
                    Title = "KamAZ truck",
                    EquipmentType = new RegularEquipment()
                },

            };

            Orders = new List<Order>
            {
                new Order(Equipments[0], 2),
                new Order(Equipments[0], 5),
                new Order(Equipments[1], 1)
            };
        }
    }
}
