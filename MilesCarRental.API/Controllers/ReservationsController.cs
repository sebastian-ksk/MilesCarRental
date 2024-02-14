using Microsoft.AspNetCore.Mvc;
using MilesCarRental.API.Utils;
using MilesCarRental.BLL.Services;
using MilesCarRental.DAL.Models;
using System.Threading.Tasks;

namespace MilesCarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsService _reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        /// <summary>
        /// Create a new reservation.
        /// </summary>
        /// <param name="reservation">The reservation information.</param>
        /// <returns>The newly created reservation.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Reservation>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            var createdReservation = await _reservationsService.CreateReservationAsync(reservation);
            return Ok(new ApiResponse<Reservation>(true, "Reservation created successfully", createdReservation));
        }

        /// <summary>
        /// Mark a reservation as complete.
        /// </summary>
        /// <param name="id">The ID of the reservation to mark as complete.</param>
        /// <returns>No content if successful, not found if reservation does not exist.</returns>
        [HttpPut("{id}/complete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CompleteReservation(int id)
        {
            var completedReservation = await _reservationsService.CompleteReservationAsync(id);
            if (completedReservation == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Get a reservation by ID.
        /// </summary>
        /// <param name="id">The ID of the reservation to retrieve.</param>
        /// <returns>The reservation if found, not found otherwise.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<Reservation>), 200)]
        [ProducesResponseType(404)]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetReservation(int id)
        {
            var reservation = await _reservationsService.GetReservationAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(new ApiResponse<Reservation>(true, "Reservation retrieved successfully", reservation));
        }
    }
}
