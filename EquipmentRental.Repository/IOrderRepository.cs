using System;
using System.Collections.Generic;
using System.Text;
using EquipmentRental.Domain.Models;

namespace EquipmentRental.Repository
{
    public interface IOrderRepository
    {
        IList<Order> GetAll();
        void Add(Order order);
    }
}
