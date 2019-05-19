using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public OrdersController(IUnitOfWork unitOfWork, ILogger<OrdersController> logger, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add(OrderInputResource orderInput)
        {
            if (orderInput == null || orderInput.CustomerId == 0 || orderInput.EquipmentId == 0 || orderInput.DaysOfRent == 0)
            {
                _logger.LogError($"[post] api/orderInput called with bad data. Data: {JsonConvert.SerializeObject(orderInput)}");
                return BadRequest();
            }

            var equipment = _unitOfWork.EquipmentRepository.Get(orderInput.EquipmentId);

            if (equipment == null)
            {
                _logger.LogError($"[post] api/orderInput called with invalid equipment id({orderInput.EquipmentId})");
                return BadRequest();
            }

            var customer = _unitOfWork.CustomerRepository.Get(orderInput.CustomerId);

            if (customer == null)
            {
                _logger.LogError($"[post] api/orderInput called with invalid customer id({orderInput.CustomerId})");
                return BadRequest();
            }

            var _order = new Order(equipment, customer, orderInput.DaysOfRent);
            _unitOfWork.OrderRepository.Add(_order);
            return Ok(_order);
        }

        [HttpGet]
        [Route("{customerId}")]
        public IActionResult Get(int customerId)
        {
            var orders = _unitOfWork.OrderRepository.Get(customerId).ToList();
            var result = _mapper.Map<List<OrderResultResource>>(orders);
            return Ok(result);
        }



        [HttpGet]
        [Route("{customerId}/invoice")]
        public IActionResult GetInvoice(int customerId)
        {
            var orders = _unitOfWork.OrderRepository.GetByCustomer(customerId);

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
            int loyaltyPoint = 0;
            foreach (var order in orders)
            {
                text.AppendLine($"#{count++}");
                text.AppendLine($"Title: {order.Equipment.Title}");
                text.AppendLine($"Price: {order.Price}");
                text.AppendLine("----------------");
                text.AppendLine();
                totalPrice += order.Price;
                loyaltyPoint += order.Equipment.EquipmentType.LoyaltyPoint;
            }

            text.AppendLine();
            text.AppendLine("#### Summery ####");
            text.AppendLine($"Total Price: {totalPrice}");
            text.AppendLine($"Bonus Point: {loyaltyPoint}");
            text.AppendLine();

            return text.ToString();
        }
    }
}
