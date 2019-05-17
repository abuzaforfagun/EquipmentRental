using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger logger;

        public OrderController(IUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Add(OrderResource order)
        {
            if (order == null || order.CustomerId == 0 || order.EquipmentId == 0 || order.DaysOfRent == 0)
            {
                logger.LogError($"[post] api/order called with bad data. Data: {JsonConvert.SerializeObject(order)}");
                return BadRequest();
            }

            var equipment = unitOfWork.EquipementRepository.Get(order.EquipmentId);

            if (equipment == null)
            {
                logger.LogError($"[post] api/order called with invalid equipment id({order.EquipmentId})");
                return BadRequest();
            }

            var customer = unitOfWork.CustomerRepository.Get(order.CustomerId);

            if (customer == null)
            {
                logger.LogError($"[post] api/order called with invalid customer id({order.CustomerId})");
                return BadRequest();
            }

            var _order = new Order(equipment, customer, order.DaysOfRent);
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
