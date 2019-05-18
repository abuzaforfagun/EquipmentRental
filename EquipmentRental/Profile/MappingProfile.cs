using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipment, EquipmentResource>()
                .ForMember(destination => destination.Type, opt => opt.MapFrom(source => source.EquipmentType.Name))
                .ForMember(destination => destination.LoyalityPoint, opt => opt.MapFrom(source=>source.EquipmentType.LoyalityPoint))
                .ReverseMap();

            CreateMap<Order, OrderResultResource>()
                .ForMember(destination => destination.Id, opt => opt.Ignore())
                .ForMember(destination => destination.Title, opt => opt.MapFrom(source => source.Equipment.Title))
                .ForMember(destination => destination.LoyalityPoint,
                    opt => opt.MapFrom(source => source.Equipment.EquipmentType.LoyalityPoint))
                .ForMember(destination => destination.Type,
                    opt => opt.MapFrom(source => source.Equipment.EquipmentType.Name));
        }
    }
}
