using MilesCarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BLL.Services
{
    public interface IRentalsRepository
    {
        Task<Rental> CreateAsync(Rental rental);
       
    }

    public class RentalsRepository : IRentalsRepository
    {
      
        private static List<Rental> _rentals = new List<Rental>
        {
           
            new Rental { Id = 1, CustomerId = 1, VehicleId = 1, StartDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(-5), Status = "Completed" }
        };

        public Task<Rental> CreateAsync(Rental rental)
        {
            rental.Id = _rentals.Any() ? _rentals.Max(r => r.Id) + 1 : 1;
            _rentals.Add(rental);
            return Task.FromResult(rental);
        }
    }
}
