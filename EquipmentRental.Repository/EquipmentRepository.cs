using EquipmentRental.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentRental.Repository.Persistence;

namespace EquipmentRental.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly IEquipmentDbContext _context;


        public EquipmentRepository(IEquipmentDbContext context)
        {
            _context = context;
        }

        public IList<Equipment> GetAll()
        {
            return _context.Equipments;
        }

        public Equipment Get(int id)
        {
            return _context.Equipments.SingleOrDefault(i => i.Id == id);
        }

        public async Task<IList<Equipment>> GetAllAsync()
        {
            var task = Task.Run(() => _context.Equipments);
            return await task;
        }

        public async Task<Equipment> GetAsync(int id)
        {
            var task = Task.Run(() => _context.Equipments.SingleOrDefault(i => i.Id == id));
            return await task;
        }
    }
}
