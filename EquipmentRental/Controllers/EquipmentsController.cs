using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EquipmentRental.Domain.Models;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<EquipmentsController> logger;
        private readonly IMapper mapper;

        public EquipmentsController(IUnitOfWork unitOfWork, ILogger<EquipmentsController> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var equipments = unitOfWork.EquipementRepository.GetAll().ToList();

            var result = mapper.Map<List<EquipmentResource>>(equipments);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = unitOfWork.EquipementRepository.Get(id);
            if (result == null)
            {
                logger.LogError($"api/controller/get/{id} Not found");
                return NotFound();
            }
            return Ok(result);
        }
    }
}
