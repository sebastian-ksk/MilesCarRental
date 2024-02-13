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
        Task<Customer> CreateCustomersAsync();
    }
    public class CustomersRepository: ICustomersRepository
    {
        private readonly MainContext context;

        public CustomersRepository(MainContext context)
        {
            this.context = context;
        }


        //create Customer method
        public Task<Customer> CreateCustomersAsync()
        {
            var customer = new Customer
            {
                FirstName = "John" 
            };
            return Task.FromResult(customer);

        }

    }
}
