using AutoMapper;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<AuthController> logger;

        public AuthController(IUnitOfWork unitOfWork, ILogger<AuthController> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginResource credentials)
        {
            var customer = unitOfWork.CustomerRepository.Get(credentials.Email.ToLower(), credentials.Password);

            if (customer != null)
            {
                var result = mapper.Map<CustomerResource>(customer);
                return Ok(result);
            }
            logger.LogError($"Invalid login attempt by {credentials.Email}, used '{credentials.Password}' as password.");
            return Unauthorized();
        }
    }
}
