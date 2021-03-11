namespace DrobnyZivnostnik.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Address;

    public interface IAddressService
    {
        Task<ICollection<AddressModel>> GetAsync();

        Task AddAsync(AddressModel model);

        Task DeleteAsync(Guid addressId);
    }
}
