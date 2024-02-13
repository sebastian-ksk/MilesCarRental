using Microsoft.AspNetCore.Mvc;

namespace MilesCarRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {

        // GET: api/vehicles
        [HttpGet]
        public IActionResult GetAvailableVehicles()
        {
            // Lógica para obtener y devolver vehículos disponibles
            return Ok(/* colección de vehículos */);
        }
    }
}
