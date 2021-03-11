namespace DrobnyZivnostnik.Services
{
    using Database.Entities;
    using Extensions;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Address;
    using Models.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : BaseService, IUserService
    {
        public async Task AddAsync(UserModel model)
        {
            DbContext.User.Add(Mapper.Map<User>(model));
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid userId)
        {
            var entity = await DbContext.User.FindAsync(userId);

            entity.SoftDelete();

            DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
        }

        public async Task<UserModel> GetByIdAsync(Guid userId)
        {
            var model = Mapper.Map<UserModel>(await DbContext.User.FindAsync(userId));

            var addresses = await DbContext.Address
                .Where(address => address.AddressId == model.AddressId || address.AddressId == model.PlaceOfBusinessId)
                .ToListAsync();

            var addressModels = Mapper.Map<ICollection<AddressModel>>(addresses);

            model.Address = addressModels.FirstOrDefault(address => address.AddressId == model.AddressId);
            model.PlaceOfBusiness = addressModels.FirstOrDefault(address => address.AddressId == model.PlaceOfBusinessId);

            return model;
        }

        public async Task<ICollection<UserListModel>> GetUserListAsync()
        {
            //TODO VIEW https://www.sqlitetutorial.net/sqlite-create-view/
            var entities = await DbContext.User
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<ICollection<UserListModel>>(entities);
        }

        public async Task SetUserActive(Guid userId)
        {
            var entity = await DbContext.User.FindAsync(userId);
            var previousUser = await DbContext.User.Where(x => x.IsActive).FirstOrDefaultAsync();

            if (previousUser.IsNotNull())
            {
                previousUser.IsActive = false;
                DbContext.User.Update(previousUser);
            }
            
            entity.IsActive = true;
            DbContext.User.Update(entity);

            await DbContext.SaveChangesAsync();
        }
    }
}
