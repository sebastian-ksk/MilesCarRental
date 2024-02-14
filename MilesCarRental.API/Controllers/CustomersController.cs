using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.BLL.Services;
using MilesCarRental.DAL.Models;

namespace MilesCarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        // POST: api/customers
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var newCustomer = await _customersService.CreateCustomerAsync(customer);
            return Ok(newCustomer);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customersService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

    }
}
