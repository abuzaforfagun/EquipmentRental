using System.Collections.Generic;
using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository;
using EquipmentRental.Repository.Presistance;

namespace EquipmentRental.Tests.Presistance
{
    public class InMemoryDbContext : DbContext
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
        }
    }
}
