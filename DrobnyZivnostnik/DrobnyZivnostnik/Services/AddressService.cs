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

    public class AddressService : BaseService, IAddressService
    {
        public async Task<ICollection<AddressModel>> GetAsync()
        {
            var entities = await DbContext.Address
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<ICollection<Address>, ICollection<AddressModel>>(entities);
        }

        public async Task AddAsync(AddressModel model)
        {
            DbContext.Address.Add(Mapper.Map<Address>(model));
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid addressId)
        {
            var entity = await DbContext.Address.FindAsync(addressId);

            entity.SoftDelete();

            DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
        }
    }
}
