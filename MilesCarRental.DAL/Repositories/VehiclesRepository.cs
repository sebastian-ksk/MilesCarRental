using MilesCarRental.DAL.Context;
using MilesCarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BLL.Services
{
    public interface IVehiclesRepository
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();
    }

    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly MainContext _context;

        public VehiclesRepository(MainContext context)
        {
            _context = context;
        }

        public   Task<IEnumerable<Vehicle>> GetAllAsync()
        {

            //create Demo data
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = 2019,
                    Color = "White",
                    LicensePlate = "ABC123",

                },
                new Vehicle
                {
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2018,
                    Color = "Black",
                    LicensePlate = "XYZ123",
       
                }
            };  

            return Task.FromResult(vehicles.AsEnumerable());
           
        }
    }
}
