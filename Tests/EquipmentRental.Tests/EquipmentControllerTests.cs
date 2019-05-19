using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EquipmentRental.Controllers;
using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Profile;
using EquipmentRental.Repository;
using EquipmentRental.Tests.Presistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Moq;
using Xunit;

namespace EquipmentRental.Tests
{
    public class EquipmentControllerTests
    {
        private EquipmentsController controller;
        private InMemoryDbContext dbContext;
        private UnitOfWork unitOfWork;
        private Mock<ILogger<EquipmentsController>> mockLogger;

        public EquipmentControllerTests()
        {
            dbContext = new InMemoryDbContext();
            unitOfWork = new UnitOfWork(dbContext);
            mockLogger = new Mock<ILogger<EquipmentsController>>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            controller = new EquipmentsController(unitOfWork, mockLogger.Object, mapper);
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
            var result = (controller.Get() as OkObjectResult).Value as IList<EquipmentResource>;

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Get_CallWith_NoParameters_ShoulReturn_EmptyList_When_NoEquipementAvailable()
        {
            dbContext.Equipments = new List<Equipment>();

            var result = (controller.Get() as OkObjectResult).Value as IList<EquipmentResource>;

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
        public void Get_CallWith_InValidEquipmentId_Should_AddLog()
        {
            var result = controller.Get(It.IsAny<int>());

            mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
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
