using System.Linq;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository.Persistence;

namespace EquipmentRental.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IEquipmentDbContext _context;

        public CustomerRepository(IEquipmentDbContext context)
        {
            _context = context;
        }
        public Customer Get(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }

        public Customer Get(string email, string password)
        {
            return _context.Customers.SingleOrDefault(c => c.Email == email && c.Password == password);
        }
    }
}
