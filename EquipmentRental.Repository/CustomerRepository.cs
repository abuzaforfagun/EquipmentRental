using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
