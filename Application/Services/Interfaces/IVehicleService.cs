namespace Application.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Vehicle;

    public interface IVehicleService : IBaseService<VehicleModel>
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<VehicleModel>> GetAsync();
    }
}
