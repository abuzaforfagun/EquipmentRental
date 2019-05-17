using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Add(OrderResource order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            var equipment = unitOfWork.EquipementRepository.Get(order.EquipmentId);
            var _order = new Order(equipment, order.DaysOfRent);
            unitOfWork.OrderRepository.Add(_order);
            return Ok(_order);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unitOfWork.OrderRepository.GetAll());
        }
    }
}
