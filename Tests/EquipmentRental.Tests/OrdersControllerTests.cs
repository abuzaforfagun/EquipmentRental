using EquipmentRental.Controllers;
using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Repository;
using EquipmentRental.Repository.Persistence;
using EquipmentRental.Tests.Persistence;
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
        private readonly OrdersController _controller;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mock<ILogger<OrdersController>> _mockLogger;
        private readonly OrderInputResource _validOrderInputResource;


        public OrdersControllerTests()
        {
            IEquipmentDbContext context = new InMemoryDbContext();
            _unitOfWork = new UnitOfWork(context);
            _mockLogger = new Mock<ILogger<OrdersController>>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _controller = new OrdersController(_unitOfWork, _mockLogger.Object, mapper);
            _validOrderInputResource = new OrderInputResource {DaysOfRent = 1, EquipmentId = 1, CustomerId = 1};
        }

        [Fact]
        public void Add_CallWith_ValidOrder_ShouldReturn_OkResult()
        {
            var result = _controller.Add(_validOrderInputResource);

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWith_ValidCustomerId_ShouldReturn_AllOrdersOfThatCustomer()
        {
            var result = (_controller.Get(1) as OkObjectResult)?.Value as IList<OrderResultResource>;

            Assert.True(result != null && result.Count == 3);
        }

        [Fact]
        public void Add_CallWith_InvalidData_ShouldReturn_BadRequest()
        {
            var result = _controller.Add(null);

            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_NegativeDaysOfRent_ShouldReturn_BadRequest()
        {
            var requestObject = new OrderInputResource()
            {
                CustomerId = 1,
                DaysOfRent = -1,
                EquipmentId = 1
            };

            var result = _controller.Add(requestObject);

            Assert.True(result is BadRequestResult);

        }

        [Fact]
        public void Add_CallWithOut_CustomerId_ShouldReturn_BadRequest()
        {
            var result = _controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 1 });

            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InvalidCustomerId_ShouldReturn_BadRequest()
        {
            var result = _controller.Add(new OrderInputResource() {DaysOfRent = 1, EquipmentId = 1, CustomerId = 12});
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InvalidCustomerId_Should_AddLog()
        {
            var result = _controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 1, CustomerId = 111 });

            _mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWithOut_CustomerId_Should_AddLog()
        {
            var result = _controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 1 });

            _mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWith_InvalidEquipmentId_ShouldReturn_BadRequest()
        {
            var result = _controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 1111, CustomerId = 1 });
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_InValidEquipmentId_Should_AddLog()
        {
            var result = _controller.Add(new OrderInputResource() { DaysOfRent = 1, EquipmentId = 100, CustomerId = 1 });

            _mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldAdd_DataInStorage()
        {
            var ordersBeforeAdd = _unitOfWork.OrderRepository.Get(1).Count;
            
            _controller.Add(_validOrderInputResource);

            var ordersAfterAdd = _unitOfWork.OrderRepository.Get(1).Count;
            Assert.Equal(ordersAfterAdd, ordersBeforeAdd + 1);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldReturn_NewlyAddedOrder()
        {
            var equipment = _unitOfWork.EquipmentRepository.Get(_validOrderInputResource.EquipmentId);
            var result = (_controller.Add(_validOrderInputResource) as OkObjectResult)?.Value as Order;

            Assert.NotNull(result);
            Assert.Equal(equipment, result.Equipment);
            Assert.Equal(_validOrderInputResource.DaysOfRent, result.RentOfDays);
        }
        
    }
}
