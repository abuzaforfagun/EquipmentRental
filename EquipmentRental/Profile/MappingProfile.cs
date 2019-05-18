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
                .ForMember(destionation => destionation.Type, opt => opt.MapFrom(source => source.EquipmentType.Name))
                .ReverseMap();
        }
    }
}
