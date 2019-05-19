using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EquipmentRental.Domain.Resources;
using EquipmentRental.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EquipmentsController> _logger;
        private readonly IMapper _mapper;

        public EquipmentsController(IUnitOfWork unitOfWork, ILogger<EquipmentsController> logger, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var equipments = _unitOfWork.EquipmentRepository.GetAll().ToList();

            var result = _mapper.Map<List<EquipmentResource>>(equipments);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _unitOfWork.EquipmentRepository.Get(id);
            if (result == null)
            {
                _logger.LogError($"api/controller/get/{id} Not found");
                return NotFound();
            }
            return Ok(result);
        }
    }
}
