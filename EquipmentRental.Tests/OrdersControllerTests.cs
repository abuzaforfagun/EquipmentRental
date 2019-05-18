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
using AutoMapper;
using EquipmentRental.Profile;
using System.Collections.Generic;

namespace EquipmentRental.Tests
{
    public class OrdersControllerTests
    {
        private OrdersController controller;
        private IUnitOfWork unitOfWork;
        private Mock<ILogger<OrdersController>> mockLogger;
        private IEquipmentDbContext context;
        private OrderInputResource _validOrderInputResource;


        public OrdersControllerTests()
        {
            context = new InMemoryDbContext();
            unitOfWork = new UnitOfWork(context);
            mockLogger = new Mock<ILogger<OrdersController>>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            controller = new OrdersController(unitOfWork, mockLogger.Object, mapper);
            _validOrderInputResource = new OrderInputResource {DaysOfRent = 1, EquipmentId = 1, CustomerId = 1};
        }

        [Fact]
        public void Add_CallWith_ValidOrder_ShouldReturn_OkResult()
        {
            var result = controller.Add(_validOrderInputResource);

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWith_ValidCustomerId_ShouldReturn_AllOrdersOfThatCustomer()
        {
            var result = (controller.Get(1) as OkObjectResult).Value as IList<OrderResultResource>;

            Assert.True(result.Count == 3);
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
            var result = controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 1 });

            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InvalidCustomerId_ShouldReturn_BadRequest()
        {
            var result = controller.Add(new OrderInputResource() {DaysOfRent = 1, EquipmentId = 1, CustomerId = 12});
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InvalidCustomerId_Should_AddLog()
        {
            var result = controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 1, CustomerId = 111 });

            mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWithOut_CustomerId_Should_AddLog()
        {
            var result = controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 1 });

            mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWith_InvalidEquipmentId_ShouldReturn_BadRequest()
        {
            var result = controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 1111, CustomerId = 1 });
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InValidEquipmentId_Should_AddLog()
        {
            var result = controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 100, CustomerId = 1 });

            mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldAdd_DataInStorage()
        {
            var ordersBeforeAdd = unitOfWork.OrderRepository.Get(1).Count;
            
            controller.Add(_validOrderInputResource);

            var ordersAfterAdd = unitOfWork.OrderRepository.Get(1).Count;
            Assert.Equal(ordersAfterAdd, ordersBeforeAdd + 1);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldReturn_NewlyAddedOrder()
        {
            var equipment = unitOfWork.EquipementRepository.Get(_validOrderInputResource.EquipmentId);
            var result = (controller.Add(_validOrderInputResource) as OkObjectResult).Value as Order;

            Assert.Equal(equipment, result.Equipment);
            Assert.Equal(_validOrderInputResource.DaysOfRent, result.RentOfDays);
        }
        
    }
}
