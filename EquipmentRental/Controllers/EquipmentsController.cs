using System;
using System.Collections.Generic;
using EquipmentRental.Domain.Models;
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

        public EquipmentsController(IUnitOfWork unitOfWork, ILogger<EquipmentsController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IList<Equipment> result = unitOfWork.EquipementRepository.GetAll();
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
