using System;
using EquipmentRental.Domain.EquipmentTypes;

namespace EquipmentRental.Domain.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEquipmentType EquipmentType { get; set; }

        public Equipment(int id, string title, IEquipmentType type)
        {
            this.Id = id;
            this.Title = title;
            this.EquipmentType = type;
        }

        public Equipment()
        {
        }
    }
}
