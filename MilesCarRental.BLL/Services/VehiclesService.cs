﻿using MilesCarRental.BLL.Exceptions;
using MilesCarRental.DAL.Context;
using MilesCarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BLL.Services
{
    public interface IVehiclesService
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
    }

    public class VehiclesService : IVehiclesService
    {
        private readonly IVehiclesRepository _vehiclesRepository;

        public VehiclesService(IVehiclesRepository vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            try
            {
                return await _vehiclesRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new BusinessException("An error occurred while retrieving all vehicles.", ex);
            }
        }
    }

}
