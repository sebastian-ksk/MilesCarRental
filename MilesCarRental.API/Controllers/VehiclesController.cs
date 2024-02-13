using Microsoft.AspNetCore.Mvc;

namespace MilesCarRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        public IActionResult GetVehicles()
        {
            return Ok("This is the list of vehicles");
        }
    }
}
