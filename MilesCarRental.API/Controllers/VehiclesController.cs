using Microsoft.AspNetCore.Mvc;
using MilesCarRental.BLL.Services;

namespace MilesCarRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {

        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(IVehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        // GET: api/vehicles
        [HttpGet]
        public async Task<IActionResult> GetAvailableVehicles()
        {
            var vehicles = await _vehiclesService.GetAllVehiclesAsync();
            return Ok(vehicles);
        }
    }
}
