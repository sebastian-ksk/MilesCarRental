using MilesCarRental.DAL.Context;
using MilesCarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BLL.Services
{
    public interface ICustomersRepository
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> GetByIdAsync(int id);
    }

    public class CustomersRepository : ICustomersRepository
    {
        private static List<Customer> _customers = new List<Customer>
        {
            new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" }
        };

        public Task<Customer> CreateAsync(Customer customer)
        {
            customer.Id = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;
            _customers.Add(customer);
            return Task.FromResult(customer);
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(customer);
        }
    }
}
