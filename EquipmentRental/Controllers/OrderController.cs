using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public OrderController(IUnitOfWork unitOfWork, ILogger<OrderController> logger)
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



        [HttpGet]
        [Route("{customerId}/invoice")]
        public IActionResult GetInvoice(int customerId)
        {
            var orders = unitOfWork.OrderRepository.GetByCustomer(customerId);

            var content = GenerateFileFromOrders(customerId, orders);

            var fileName = $"\"Invoice_{customerId}_{DateTime.Now.Ticks}\"";
            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            return Content(content, "text/plain");

        }

        private string GenerateFileFromOrders(int customerId, IList<Order> orders)
        {
            var text = new StringBuilder();
            int count = 1;
            double totalPrice = 0;
            int loyalityPoint = 0;
            foreach (var order in orders)
            {
                text.AppendLine($"#{count++}");
                text.AppendLine($"Title: {order.Equipment.Title}");
                text.AppendLine($"Price: {order.Price}");
                text.AppendLine("----------------");
                text.AppendLine();
                totalPrice += order.Price;
                loyalityPoint += order.Equipment.EquipmentType.LoyalityPoint;
            }

            text.AppendLine();
            text.AppendLine("#### Summery ####");
            text.AppendLine($"Total Price: {totalPrice}");
            text.AppendLine($"Bonus Point: {loyalityPoint}");
            text.AppendLine();

            return text.ToString();
        }
    }
}
