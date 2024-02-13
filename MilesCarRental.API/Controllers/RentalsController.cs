using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilesCarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateRental([FromBody] string rental)
        {
            return Ok(/* lógica para crear un alquiler */);
        }
    }
}
