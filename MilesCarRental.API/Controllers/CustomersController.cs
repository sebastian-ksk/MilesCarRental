using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilesCarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        // POST: api/customers
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] string customer)
        {
           return Ok(/* lógica para crear un cliente */);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            // Lógica para obtener la información de un cliente específico
            return Ok(/* cliente */);
        }

    }
}
