using MilesCarRental.DAL.Context;
using MilesCarRental.DAL.Exceptions;
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

        public async Task<Customer> CreateAsync(Customer customer)
        {
            try
            {
                customer.Id = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;
                _customers.Add(customer);
                return await Task.FromResult(customer);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while creating the customer.", ex);
            }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            try
            {
                var customer = _customers.FirstOrDefault(c => c.Id == id);
                if (customer == null)
                {
                    throw new DataAccessException($"Customer with ID {id} was not found.");
                }
                return await Task.FromResult(customer);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while retrieving the customer.", ex);
            }
        }

    }
}
