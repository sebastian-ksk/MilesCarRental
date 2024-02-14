using MilesCarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BLL.Services
{
    public interface IRentalsService
    {
        Task<Rental> CreateRentalAsync(Rental rental);
    }

    public class RentalsService : IRentalsService
    {
        private readonly IRentalsRepository _rentalsRepository;

        public RentalsService(IRentalsRepository rentalsRepository)
        {
            _rentalsRepository = rentalsRepository;
        }

        public Task<Rental> CreateRentalAsync(Rental rental)
        {
            return _rentalsRepository.CreateAsync(rental);
        }
    }
}
