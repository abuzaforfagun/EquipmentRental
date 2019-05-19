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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUnitOfWork unitOfWork, ILogger<AuthController> logger, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginResource credentials)
        {
            var customer = _unitOfWork.CustomerRepository.Get(credentials.Email.ToLower(), credentials.Password);

            if (customer != null)
            {
                var result = _mapper.Map<CustomerResource>(customer);
                return Ok(result);
            }
            _logger.LogError($"Invalid login attempt by {credentials.Email}, used '{credentials.Password}' as password.");
            return Unauthorized();
        }
    }
}
