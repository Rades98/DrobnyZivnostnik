namespace DrobnyZivnostnik.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Address;

    public interface IAddressService
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<AddressModel>> GetAsync();

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task AddAsync(AddressModel model);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(Guid addressId);
    }
}
