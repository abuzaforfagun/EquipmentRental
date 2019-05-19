using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EquipmentRental.Controllers;
using EquipmentRental.Domain.Models;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Profile;
using EquipmentRental.Repository;
using EquipmentRental.Tests.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Moq;
using Xunit;

namespace EquipmentRental.Tests
{
    public class EquipmentControllerTests
    {
        private readonly EquipmentsController _controller;
        private readonly InMemoryDbContext _dbContext;
        private readonly Mock<ILogger<EquipmentsController>> _mockLogger;

        public EquipmentControllerTests()
        {
            _dbContext = new InMemoryDbContext();
            var unitOfWork = new UnitOfWork(_dbContext);
            _mockLogger = new Mock<ILogger<EquipmentsController>>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _controller = new EquipmentsController(unitOfWork, _mockLogger.Object, mapper);
        }

        [Fact]
        public void Get_CallWith_NoParameter_ShouldReturn_OkResponse()
        {
            var result = _controller.Get();

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWith_NoParameter_ShouldReturn_AllEquipments()
        {
            var result = (_controller.Get() as OkObjectResult)?.Value as IList<EquipmentResource>;

            Assert.True(result != null && result.Count > 0);
        }

        [Fact]
        public void Get_CallWith_NoParameters_ShouldReturn_EmptyList_When_NoEquipmentAvailable()
        {
            _dbContext.Equipments = new List<Equipment>();

            var result = (_controller.Get() as OkObjectResult)?.Value as IList<EquipmentResource>;

            if (result != null) Assert.Equal(0, result.Count);
        }
        

        [Fact]
        public void Get_CallWith_ValidEquipmentId_ShouldReturn_OkResponse()
        {
            var existingEquipment = _dbContext.Equipments.First();
            var result = _controller.Get(existingEquipment.Id);

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWith_InValidEquipmentId_ShouldReturn_NotFound()
        {
            var result = _controller.Get(It.IsAny<int>());

            Assert.True(result is NotFoundResult);
        }

        [Fact]
        public void Get_CallWith_InValidEquipmentId_Should_AddLog()
        {
            var result = _controller.Get(It.IsAny<int>());

            _mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact] 

        public void Get_CallWith_ValidEquipmentId_ShouldReturn_SpecificEquipement()
        {
            var existingEquipment = _dbContext.Equipments.First();
            var result = (_controller.Get(existingEquipment.Id) as OkObjectResult)?.Value as Equipment;

            Assert.Equal(existingEquipment, result);
        }
    }
}
