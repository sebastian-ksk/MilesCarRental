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

        public Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            return _reservationsRepository.CreateAsync(reservation);
        }

        public async Task<Reservation> CompleteReservationAsync(int id)
        {
            var reservation = await _reservationsRepository.GetByIdAsync(id);
            if (reservation != null)
            {
                reservation.Status = "Completed";
                await _reservationsRepository.UpdateAsync(reservation);
            }
            return reservation;
        }

        public Task<Reservation> GetReservationAsync(int id)
        {
            return _reservationsRepository.GetByIdAsync(id);
        }
    }
}
