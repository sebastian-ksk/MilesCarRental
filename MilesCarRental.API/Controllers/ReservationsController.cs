using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.BLL.Services;
using MilesCarRental.DAL.Models;

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

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            var createdReservation = await _reservationsService.CreateReservationAsync(reservation);
            return Ok(createdReservation);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteReservation(int id)
        {
            var completedReservation = await _reservationsService.CompleteReservationAsync(id);
            if (completedReservation == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetReservation(int id)
        {
            var reservation = await _reservationsService.GetReservationAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }
    }
}
