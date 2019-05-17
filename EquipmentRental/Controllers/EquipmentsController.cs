using System;
using System.Collections.Generic;
using EquipmentRental.Domain.Models;
using EquipmentRental.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public EquipmentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
                return NotFound();
            }
            return Ok(result);
        }
    }
}
