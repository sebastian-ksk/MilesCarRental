using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilesCarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {

        // POST: api/reservations
        [HttpPost]
        public IActionResult CreateReservation([FromBody] string reservation)
        {
          
            return Ok(/* lógica para crear una reserva */);
        }

        // PUT: api/reservations/{id}/complete
        [HttpPut("{id}/complete")]
        public IActionResult CompleteReservation(int id)
        {
          
            return NoContent(); // O devolver el estado actualizado de la reserva
        }

        // GET: api/reservations/{id}
        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            // Lógica para obtener los detalles de una reserva específica
            return Ok(/* reserva */);
        }

    }
}
