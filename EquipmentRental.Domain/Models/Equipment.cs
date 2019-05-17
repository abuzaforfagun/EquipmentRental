using EquipmentRental.Domain.EquipmentTypes;

namespace EquipmentRental.Domain.Models
{
    public class Equipment
    {
        public string Title { get; set; }
        public IEquipmentType EquipmentType { get; set; }

        public Equipment(string title, IEquipmentType type)
        {
            this.Title = title;
            this.EquipmentType = type;
        }

        public Equipment()
        {
            
        }
    }
}
