using Microsoft.AspNetCore.Mvc;
using MilesCarRental.BLL.Services;
using MilesCarRental.API.Utils;
using MilesCarRental.DAL.Models;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        /// Create a new customer.
        /// </summary>
        /// <param name="customer">The customer to create.</param>
        /// <returns>The newly created customer.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Customer>), 200)]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var newCustomer = await _customersService.CreateCustomerAsync(customer);
            return Ok(new ApiResponse<Customer>(true, "Customer created successfully", newCustomer));
        }

        /// <summary>
        /// Get a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The customer with the specified ID.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<Customer>), 200)]
        [ProducesResponseType(404)]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customersService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(new ApiResponse<Customer>(true, "Customer retrieved successfully", customer));
        }
    }
}
