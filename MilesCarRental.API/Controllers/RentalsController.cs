using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.BLL.Services;
using MilesCarRental.DAL.Models;

namespace MilesCarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalsService _rentalsService;

        public RentalsController(IRentalsService rentalsService)
        {
            _rentalsService = rentalsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental([FromBody] Rental rental)
        {
            var createdRental = await _rentalsService.CreateRentalAsync(rental);
            return Ok(createdRental);
        }
    }
}
