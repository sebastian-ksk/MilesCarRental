using MilesCarRental.BLL.Exceptions;
using MilesCarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BLL.Services
{

    public interface IReservationsService
    {
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task<Reservation> CompleteReservationAsync(int id);
        Task<Reservation> GetReservationAsync(int id);
    }
    

    public class ReservationsService : IReservationsService
    {
        private readonly IReservationsRepository _reservationsRepository;

        public ReservationsService(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            try
            {
                return await _reservationsRepository.CreateAsync(reservation);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error creating the reservation.", ex);
            }
        }

        public async Task<Reservation> CompleteReservationAsync(int id)
        {
            try
            {
                var reservation = await _reservationsRepository.GetByIdAsync(id);
                if (reservation != null)
                {
                    reservation.Status = "Completed";
                    await _reservationsRepository.UpdateAsync(reservation);
                }
                return reservation;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error completing the reservation.", ex);
            }
        }

        public async Task<Reservation> GetReservationAsync(int id)
        {
            try
            {
                return await _reservationsRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
   
                throw new BusinessException("Error obtaining reservation.", ex);
            }
        }
    }
}
