using System.Collections.Generic;
using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository;

namespace EquipmentRental.Tests.Presistance
{
    public class InMemoryEquipementRepository : EquipmentRepository
    {
        public InMemoryEquipementRepository():base(SetDummyList())
        {
            
        }

        private static IList<Equipment> SetDummyList()
        {
            var data = new List<Equipment>
            {
                new Equipment()
                {
                    Title = "Caterpillar bulldozer",
                    EquipmentType = new HeavyEquipement()
                },
                new Equipment()
                {
                    Title = "KamAZ truck",
                    EquipmentType = new RegularEquipment()
                },

            };
            return data;
        }
    }
}
