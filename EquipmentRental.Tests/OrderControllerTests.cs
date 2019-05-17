using System;
using System.Collections.Generic;
using System.Text;
using EquipmentRental.Controllers;
using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository;
using EquipmentRental.Repository.Presistance;
using EquipmentRental.Tests.Presistance;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EquipmentRental.Tests
{
    public class OrderControllerTests
    {
        private OrderController controller;
        private IUnitOfWork unitOfWork;
        private IDbContext context;
        public OrderControllerTests()
        {
            context = new InMemoryDbContext();
            unitOfWork = new UnitOfWork(context);
            controller = new OrderController(unitOfWork);
        }

        [Fact]
        public void Add_CallWith_ValidOrder_ShouldReturn_OkResult()
        {
            var result = controller.Add(new Order(It.IsAny<Equipment>()));

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Add_CallWith_InvalidData_ShouldReturn_BadRequest()
        {
            var result = controller.Add(null);

            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldAdd_DataInStorage()
        {
            var ordersBeforeAdd = unitOfWork.OrderRepository.GetAll().Count;

            var order = new Order(new Equipment(10, "Order no 10", new RegularEquipment()));
            controller.Add(order);

            var ordersAfterAdd = unitOfWork.OrderRepository.GetAll().Count;
            Assert.Equal(ordersAfterAdd, ordersBeforeAdd + 1);
        }

        [Fact]
        public void Add_CallWith_ValidData_ShouldReturn_NewlyAddedOrder()
        {
            var order = new Order(new Equipment(10, "Order no 10", new RegularEquipment()));

            var result = (controller.Add(order) as OkObjectResult).Value as Order;

            Assert.Equal(result, order);
        }
    }
}
