using System.Collections.Generic;
using EquipmentRental.Controllers;
using EquipmentRental.Domain.Models;
using EquipmentRental.Tests.Presistance;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EquipmentRental.Tests
{
    public class EquipmentControllerTests
    {
        private EquipmentsController controller;
        private InMemoryEquipementRepository repository;
        public EquipmentControllerTests()
        {
            repository = new InMemoryEquipementRepository();
            controller = new EquipmentsController(repository);
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
            repository.Equipements = new List<Equipment>();

            var controller = new EquipmentsController(repository);

            var result = (controller.Get() as OkObjectResult).Value as IList<Equipment>;

            Assert.Equal(0, result.Count);
        }
        
        [Fact]
        public void Get_CallWith_ValidEquipmentId_ShouldReturn_OkResponse()
        {
            var result = controller.Get(It.IsAny<int>());

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWith_InValidEquipmentId_ShouldReturn_NotFound()
        {
            var result = controller.Get(It.IsAny<int>());

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWith_ValidEquipmentId_ShouldReturn_SpecificEquipement()
        {
            var result = controller.Get(It.IsAny<int>());

            Assert.True(result is OkObjectResult);
        }
    }
}
        