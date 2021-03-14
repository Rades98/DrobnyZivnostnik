namespace DrobnyZivnostnik.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Address;

    public interface IAddressService : IBaseService<AddressModel>
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<AddressModel>> GetAsync();
    }
}
