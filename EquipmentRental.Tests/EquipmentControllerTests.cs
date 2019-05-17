using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentRental.Controllers;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository;
using EquipmentRental.Tests.Presistance;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EquipmentRental.Tests
{
    public class EquipmentControllerTests
    {
        private EquipmentsController controller;
        private InMemoryDbContext dbContext;
        private UnitOfWork unitOfWork;

        public EquipmentControllerTests()
        {
            dbContext = new InMemoryDbContext();
            unitOfWork = new UnitOfWork(dbContext);
            controller = new EquipmentsController(unitOfWork);
        }

        [Fact]
        public void Get_CallWith_NoParametere_ShouldReturn_OkResponse()
        {
            var result = controller.Get();

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWith_NoParametere_ShouldReturn_AllEquipements()
        {
            var result = (controller.Get() as OkObjectResult).Value as IList<Equipment>;

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Get_CallWith_NoParameters_ShoulReturn_EmptyList_When_NoEquipementAvailable()
        {
            dbContext.Equipments = new List<Equipment>();

            var result = (controller.Get() as OkObjectResult).Value as IList<Equipment>;

            Assert.Equal(0, result.Count);
        }
        
        [Fact]
        public void Get_CallWith_ValidEquipmentId_ShouldReturn_OkResponse()
        {
            var existingEquipment = dbContext.Equipments.First();
            var result = controller.Get(existingEquipment.Id);

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWith_InValidEquipmentId_ShouldReturn_NotFound()
        {
            var result = controller.Get(It.IsAny<int>());

            Assert.True(result is NotFoundResult);
        }

        [Fact]
        public void Get_CallWith_ValidEquipmentId_ShouldReturn_SpecificEquipement()
        {
            var existingEquipment = dbContext.Equipments.First();
            var result = (controller.Get(existingEquipment.Id) as OkObjectResult).Value as Equipment;

            Assert.Equal(existingEquipment, result);
        }
    }
}
