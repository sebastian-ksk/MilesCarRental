using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.BLL.Services;

namespace MilesCarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService customersService;

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;
        }

        // POST: api/customers
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] string customer)
        {

            var NewCostumer = customersService.CreateCostumerService();
             return Ok(NewCostumer);
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
