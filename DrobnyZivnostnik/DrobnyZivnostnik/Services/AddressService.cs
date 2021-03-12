namespace DrobnyZivnostnik.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Database.Entities;
    using Extensions;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Address;

    /// <summary>
    /// Address service
    /// </summary>
    /// <seealso cref="BaseService" />
    /// <seealso cref="IAddressService" />
    public class AddressService : BaseService, IAddressService
    {
        /// <inheritdoc/>
        public async Task<ICollection<AddressModel>> GetAsync()
        {
            var entities = await DbContext.Address
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<ICollection<Address>, ICollection<AddressModel>>(entities);
        }

        /// <inheritdoc/>
        public async Task AddAsync(AddressModel model)
        {
            DbContext.Address.Add(Mapper.Map<Address>(model));
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid addressId)
        {
            var entity = await DbContext.Address.FindAsync(addressId);

            entity.SoftDelete();

            DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
        }
    }
}
