using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;

namespace EquipmentRental.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipment, EquipmentResource>()
                .ForMember(destination => destination.Type, opt => opt.MapFrom(source => source.EquipmentType.Name))
                .ForMember(destination => destination.LoyaltyPoint, opt => opt.MapFrom(source=>source.EquipmentType.LoyaltyPoint))
                .ReverseMap();

            CreateMap<Order, OrderResultResource>()
                .ForMember(destination => destination.Id, opt => opt.Ignore())
                .ForMember(destination => destination.Title, opt => opt.MapFrom(source => source.Equipment.Title))
                .ForMember(destination => destination.LoyaltyPoint,
                    opt => opt.MapFrom(source => source.Equipment.EquipmentType.LoyaltyPoint))
                .ForMember(destination => destination.Type,
                    opt => opt.MapFrom(source => source.Equipment.EquipmentType.Name));
        }
    }
}
