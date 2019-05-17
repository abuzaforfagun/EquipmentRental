using System;
using System.Collections.Generic;
using System.Text;
using EquipmentRental.Repository.Presistance;

namespace EquipmentRental.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEquipementRepository EquipementRepository { get; set; }

        public UnitOfWork(IDbContext context)
        {
            EquipementRepository = new EquipmentRepository(context);
        }
    }
}
