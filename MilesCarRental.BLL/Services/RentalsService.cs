using MilesCarRental.BLL.Exceptions;
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
            try {              
                
                _rentalsRepository = rentalsRepository;
            }
            catch(Exception ex)
            {
                  throw new BusinessException("Error creating rental service", ex);
            }
        }

        public Task<Rental> CreateRentalAsync(Rental rental)
        {
            try
            {
                return _rentalsRepository.CreateAsync(rental);
            }
            catch(Exception ex)
            {
                throw new BusinessException("Error creating rental", ex);
            }
        }
    }
}
