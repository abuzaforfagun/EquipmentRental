using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentRental.Domain.Resources
{
    public class OrderResource
    {
        public int EquipmentId { get; set; }
        public int DaysOfRent { get; set; }
    }
}
