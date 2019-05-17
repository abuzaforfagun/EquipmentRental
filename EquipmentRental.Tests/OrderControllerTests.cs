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
        private OrderResource _validOrderResource;
        public OrderControllerTests()
        {
            context = new InMemoryDbContext();
            unitOfWork = new UnitOfWork(context);

            mockLogger = new Mock<ILogger<EquipmentsController>>();
            controller = new OrderController(unitOfWork, mockLogger.Object);
            _validOrderResource = new OrderResource {DaysOfRent = 1, EquipmentId = 1, CustomerId = 1};
        }

        [Fact]
        public void Add_CallWith_ValidOrder_ShouldReturn_OkResult()
        {
            var result = controller.Add(_validOrderResource);

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Add_CallWith_InvalidData_ShouldReturn_BadRequest()
        {
            var result = controller.Add(null);

            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWithOut_CustomerId_ShouldReturn_BadRequest()
        {
            var result = controller.Add(new OrderResource() { DaysOfRent = 1, EquipmentId = 1 });

            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InvalidCustomerId_ShouldReturn_BadRequest()
        {
            var result = controller.Add(new OrderResource() {DaysOfRent = 1, EquipmentId = 1, CustomerId = 12});
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InvalidCustomerId_Should_AddLog()
        {
            var result = controller.Add(new OrderResource() { DaysOfRent = 1, EquipmentId = 1, CustomerId = 111 });

            mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWithOut_CustomerId_Should_AddLog()
        {
            var result = controller.Add(new OrderResource() { DaysOfRent = 1, EquipmentId = 1 });

            mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWith_InvalidEquipmentId_ShouldReturn_BadRequest()
        {
            var result = controller.Add(new OrderResource() { DaysOfRent = 1, EquipmentId = 1111, CustomerId = 1 });
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InValidEquipmentId_Should_AddLog()
        {
            var result = controller.Add(new OrderResource() { DaysOfRent = 1, EquipmentId = 100, CustomerId = 1 });

            mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldAdd_DataInStorage()
        {
            var ordersBeforeAdd = unitOfWork.OrderRepository.GetAll().Count;
            
            controller.Add(_validOrderResource);

            var ordersAfterAdd = unitOfWork.OrderRepository.GetAll().Count;
            Assert.Equal(ordersAfterAdd, ordersBeforeAdd + 1);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldReturn_NewlyAddedOrder()
        {
            var equipment = unitOfWork.EquipementRepository.Get(_validOrderResource.EquipmentId);
            var result = (controller.Add(_validOrderResource) as OkObjectResult).Value as Order;

            Assert.Equal(equipment, result.Equipment);
            Assert.Equal(_validOrderResource.DaysOfRent, result.RentOfDays);
        }
    }
}
