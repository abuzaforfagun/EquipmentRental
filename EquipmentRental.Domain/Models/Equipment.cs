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
            Id = id;
            Title = title;
            EquipmentType = type;
        }

        public Equipment()
        {
        }
    }
}
