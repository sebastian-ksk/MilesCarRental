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
        Task<Customer> CreateCostumerService();
    }

    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }


        public Task<Customer> CreateCostumerService()
        {
            return _customersRepository.CreateCustomersAsync();
        }


    }
}
