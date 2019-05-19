using System.Collections.Generic;
using EquipmentRental.Domain.EquipmentTypes;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository.Persistence;

namespace EquipmentRental.Tests.Persistence
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
                    EquipmentType = new HeavyEquipment()
                },
                new Equipment()
                {
                    Id = 2,
                    Title = "KamAZ truck",
                    EquipmentType = new RegularEquipment()
                },

            };

            Customers = new List<Customer>
            {
                new Customer{ Id = 1, Email = "jhon@email.com", Password = "123" }
            };

            Orders = new List<Order>
            {
                new Order(Equipments[0], Customers[0], 2),
                new Order(Equipments[0], Customers[0], 5),
                new Order(Equipments[1], Customers[0], 1)
            };
        }
    }
}
