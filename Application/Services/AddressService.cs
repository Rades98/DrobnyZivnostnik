namespace Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Models.Address;
    using Domain.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Address service
    /// </summary>
    public class AddressService : BaseService<AddressModel, Address>, IAddressService
    {
        public async Task<ICollection<AddressModel>> GetAsync()
        {
            var entities = await DbContext.Address
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<ICollection<Address>, ICollection<AddressModel>>(entities);
        }
    }
}
