using MilesCarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BLL.Services
{
    public interface IReservationsRepository
    {
        Task<Reservation> CreateAsync(Reservation reservation);
        Task<Reservation> GetByIdAsync(int id);
        Task<Reservation> UpdateAsync(Reservation reservation);
    }

    public class ReservationsRepository : IReservationsRepository
    {
        private static List<Reservation> _reservations = new List<Reservation>
        {
            new Reservation { Id = 1, CustomerId = 1, VehicleId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(1), Status = "Reserved" }
        };

        public Task<Reservation> CreateAsync(Reservation reservation)
        {
            reservation.Id = _reservations.Any() ? _reservations.Max(r => r.Id) + 1 : 1;
            _reservations.Add(reservation);
            return Task.FromResult(reservation);
        }

        public Task<Reservation> GetByIdAsync(int id)
        {
            var reservation = _reservations.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(reservation);
        }

        public Task<Reservation> UpdateAsync(Reservation updatedReservation)
        {
            // Simula la actualización de una reserva
            var reservation = _reservations.FirstOrDefault(r => r.Id == updatedReservation.Id);
            if (reservation != null)
            {
                _reservations.Remove(reservation);
                _reservations.Add(updatedReservation);
                return Task.FromResult(updatedReservation);
            }
            return Task.FromResult<Reservation>(null);
        }
    }
}
