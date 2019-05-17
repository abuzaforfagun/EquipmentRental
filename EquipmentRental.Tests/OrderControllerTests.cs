﻿using EquipmentRental.Controllers;
using EquipmentRental.Domain.EquipementTypes;
using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;
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
            var result = controller.Add(new OrderResource());

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

            var orderResource = new OrderResource
            {
                DaysOfRent = 2,
                EquipmentId = 10
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
