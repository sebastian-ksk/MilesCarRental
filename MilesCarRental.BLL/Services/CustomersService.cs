using MilesCarRental.BLL.Exceptions;
using MilesCarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BLL.Services
{
    public interface ICustomersService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int id);
    }

    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public Task<Customer> CreateCustomerAsync(Customer customer)
        {
            try
            {
                return _customersRepository.CreateAsync(customer);

            }catch(Exception ex)
            {
                throw new BusinessException("Error creating customer", ex);
            }
            
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                return _customersRepository.GetByIdAsync(id);
            }
            catch(Exception ex)
            {
                throw new BusinessException("Error getting customer", ex);
            }
        }
    }
}
