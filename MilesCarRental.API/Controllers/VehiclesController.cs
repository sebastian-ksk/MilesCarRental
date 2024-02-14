using Microsoft.AspNetCore.Mvc;
using MilesCarRental.API.Utils;
using MilesCarRental.BLL.Services;
using MilesCarRental.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Get all available vehicles.
        /// </summary>
        /// <returns>A list of available vehicles.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<Vehicle>>), 200)]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetAvailableVehicles()
        {
            var vehicles = await _vehiclesService.GetAllVehiclesAsync();
            return Ok(new ApiResponse<IEnumerable<Vehicle>>(true, "Available vehicles retrieved successfully", vehicles));
        }
    }
}
