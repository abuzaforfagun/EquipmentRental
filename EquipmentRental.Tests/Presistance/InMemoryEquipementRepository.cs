using System;
using System.Collections.Generic;
using System.Text;
using EquipmentRental.Repository;

namespace EquipmentRental.Tests.Presistance
{
    public class InMemoryEquipementRepository : EquipmentRepository
    {
        public InMemoryEquipementRepository():base(SetDummyList())
        {
            
        }

        private static IList<string> SetDummyList()
        {
            var data = new List<string> {"Item 1", "Item 2"};
            return data;
        }
    }
}
