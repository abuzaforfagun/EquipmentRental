using System.Collections.Generic;
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

        public IActionResult Get()
        {
            IList<string> result = repository.GetAll();
            return Ok(result);
        }
    }
}
