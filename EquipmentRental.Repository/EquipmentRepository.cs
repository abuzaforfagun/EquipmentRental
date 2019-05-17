using System;
using EquipmentRental.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Repository.Presistance;

namespace EquipmentRental.Repository
{
    public class EquipmentRepository : IEquipementRepository
    {
        private readonly IDbContext context;


        public EquipmentRepository(IDbContext context)
        {
            this.context = context;
        }

        public IList<Equipment> GetAll()
        {
            return context.Equipments;
        }

        public Equipment Get(int id)
        {
            return context.Equipments.SingleOrDefault(i => i.Id == id);
        }
    }
}
