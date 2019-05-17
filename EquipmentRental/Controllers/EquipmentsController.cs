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
        private readonly IEquipementRepository repository;

        public EquipmentsController(IEquipementRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IList<Equipment> result = repository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = repository.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
