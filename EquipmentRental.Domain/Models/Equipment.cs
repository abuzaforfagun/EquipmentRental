using System;
using System.Collections.Generic;
using System.Text;
using EquipmentRental.Domain.EquipmentTypes;

namespace EquipmentRental.Domain.Models
{
    public class Equipment
    {
        public string Title { get; set; }
        public IEquipmentType EquipmentType { get; set; }
    }
}
