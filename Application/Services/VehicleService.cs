namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Services;
    using Domain.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Vehicle;

    class VehicleService : BaseService<VehicleModel, Vehicle>, IVehicleService
    {
        public async Task<ICollection<VehicleModel>> GetAsync()
        {
            var entities = await DbContext.Vehicle.Where(vehicle => !vehicle.Deleted)
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<ICollection<Vehicle>, ICollection<VehicleModel>>(entities);
        }
    }
}
