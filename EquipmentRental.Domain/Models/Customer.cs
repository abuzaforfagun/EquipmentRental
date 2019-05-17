using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentRental.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
