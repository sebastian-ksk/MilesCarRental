using Microsoft.AspNetCore.Mvc;
using MilesCarRental.API.Utils;
using MilesCarRental.BLL.Services;
using MilesCarRental.DAL.Models;
using System.Threading.Tasks;

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

        /// <summary>
        /// Create a new rental.
        /// </summary>
        /// <param name="rental">The rental information.</param>
        /// <returns>The newly created rental.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Rental>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRental([FromBody] Rental rental)
        {
            var createdRental = await _rentalsService.CreateRentalAsync(rental);
            return Ok(new ApiResponse<Rental>(true, "Rental created successfully", createdRental));
        }
    }
}
