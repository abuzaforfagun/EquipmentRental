using EquipmentRental.Controllers;
using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Repository;
using EquipmentRental.Repository.Presistance;
using EquipmentRental.Tests.Presistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Moq;
using System;
using Xunit;

namespace EquipmentRental.Tests
{
    public class OrderControllerTests
    {
        private OrderController controller;
        private IUnitOfWork unitOfWork;
        private Mock<ILogger<EquipmentsController>> mockLogger;
        private IEquipmentDbContext context;
        public OrderControllerTests()
        {
            context = new InMemoryDbContext();
            unitOfWork = new UnitOfWork(context);

            mockLogger = new Mock<ILogger<EquipmentsController>>();
            controller = new OrderController(unitOfWork, mockLogger.Object);
        }

        [Fact]
        public void Add_CallWith_ValidOrder_ShouldReturn_OkResult()
        {
            var result = controller.Add(new OrderResource(){DaysOfRent = 1, EquipmentId = 1});

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Add_CallWith_InvalidData_ShouldReturn_BadRequest()
        {
            var result = controller.Add(null);

            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InValidEquipmentId_Should_AddLog()
        {
            var result = controller.Add(It.IsAny<OrderResource>());

            mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldAdd_DataInStorage()
        {
            var ordersBeforeAdd = unitOfWork.OrderRepository.GetAll().Count;

            var orderResource = new OrderResource
            {
                DaysOfRent = 2,
                EquipmentId = 2
            };
            controller.Add(orderResource);

            var ordersAfterAdd = unitOfWork.OrderRepository.GetAll().Count;
            Assert.Equal(ordersAfterAdd, ordersBeforeAdd + 1);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldReturn_NewlyAddedOrder()
        {
            var orderResource = new OrderResource
            {
                DaysOfRent = 4,
                EquipmentId = 1
            };
            var equipment = unitOfWork.EquipementRepository.Get(orderResource.EquipmentId);
            var result = (controller.Add(orderResource) as OkObjectResult).Value as Order;

            Assert.Equal(equipment, result.Equipment);
            Assert.Equal(orderResource.DaysOfRent, result.RentOfDays);
        }
    }
}
