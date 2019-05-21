using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Customer> GetAsync(int id)
        {
            var task = Task.Run(() => _context.Customers.SingleOrDefault(c => c.Id == id));
            return await task;
        }

        public async Task<Customer> GetAsync(string email, string password)
        {
            var task = Task.Run(() => _context.Customers.SingleOrDefault(c => c.Email == email && c.Password == password));
            return await task;
        }
    }
}
