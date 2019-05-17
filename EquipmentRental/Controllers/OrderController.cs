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
            if (order == null)
            {
                logger.LogError($"[post] api/order called with bad data. Data: {JsonConvert.SerializeObject(order)}");
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
