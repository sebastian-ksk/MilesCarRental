using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
