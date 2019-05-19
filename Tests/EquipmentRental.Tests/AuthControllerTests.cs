using AutoMapper;
using EquipmentRental.Controllers;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Profile;
using EquipmentRental.Repository;
using EquipmentRental.Tests.Presistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Moq;
using System;
using Xunit;

namespace EquipmentRental.Tests
{
    public class AuthControllerTests
    {
        private AuthController controller;
        private InMemoryDbContext dbContext;
        private UnitOfWork unitOfWork;
        private Mock<ILogger<AuthController>> mockLogger;


        public AuthControllerTests()
        {
            dbContext = new InMemoryDbContext();
            unitOfWork = new UnitOfWork(dbContext);
            mockLogger = new Mock<ILogger<AuthController>>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            controller = new AuthController(unitOfWork, mockLogger.Object, mapper);
        }

        [Fact]
        public void Get_CallWith_ValidCredential_ShouldReturn_OkResponse()
        {
            var credential = new LoginResource {Email = "jhon@email.com", Password = "123"};
            var result = controller.Login(credential);

            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Get_CallWith_InvalidCredential_ShouldReturn_UnauthorizedResponse()
        {
            var credential = new LoginResource {Email = "jn@email.com", Password = "123"};
            var result = controller.Login(credential);

            Assert.True(result is UnauthorizedResult);
        }

        [Fact]
        public void Get_CallWith_InvalidCredential_Should_LogActivity()
        {
            var credential = new LoginResource {Email = "oka@email.com", Password = "123"};
            var result = controller.Login(credential);

            mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public void Get_CallWith_ValidCredential_ShouldReturn_UserDetails()
        {
            var credential = new LoginResource {Email = "jhon@email.com", Password = "123"};
            var result = (controller.Login(credential) as OkObjectResult).Value as CustomerResource;

            Assert.Equal(1, result.Id);
        }
    }
}
