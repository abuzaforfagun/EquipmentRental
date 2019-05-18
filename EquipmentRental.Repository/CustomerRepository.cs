using System.Linq;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository.Presistance;

namespace EquipmentRental.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IEquipmentDbContext context;

        public CustomerRepository(IEquipmentDbContext context)
        {
            this.context = context;
        }
        public Customer Get(int id)
        {
            return context.Customers.SingleOrDefault(c => c.Id == id);
        }

        public Customer Get(string email, string password)
        {
            return context.Customers.SingleOrDefault(c => c.Email == email && c.Password == password);
        }
    }
}
