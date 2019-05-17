using EquipmentRental.Domain.Models;
using System.Collections.Generic;
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
        
    }
}
