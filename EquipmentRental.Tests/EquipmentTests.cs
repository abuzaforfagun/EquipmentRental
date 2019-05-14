using System;
using System.Collections;
using System.Collections.Generic;
using EquipmentRental.Controllers;
using EquipmentRental.Tests.Presistance;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EquipmentRental.Tests
{
    public class EquipmentTests
    {
        private EquipmentsController controller;
        private InMemoryEquipementRepository repository;
        public EquipmentTests()
        {
            repository = new InMemoryEquipementRepository();
            controller = new EquipmentsController(repository);
        }

        [Fact]
        public void Get_CallWithNoParametere_ShouldReturn_OkResponse()
        {
            var result = controller.Get();

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWithNoParametere_ShouldReturn_AllEquipements()
        {
            var result = (controller.Get() as OkObjectResult).Value as IList<string>;

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Get_CallWithNoParameters_ShoulReturn_EmptyList_When_NoEquipementAvailable()
        {
            repository.Equipements = new List<string>();

            var controller = new EquipmentsController(repository);

            var result = (controller.Get() as ObjectResult).Value as IList<string>;

            Assert.Equal(0, result.Count);
        }
    }
}
