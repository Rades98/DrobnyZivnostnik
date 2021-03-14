namespace DrobnyZivnostnik.Services
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Database.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Address;
    using Models.User;
    using Models.Vehicle;

    /// <summary>
    /// User service
    /// </summary>
    /// <seealso cref="IUserService" />
    public class UserService : BaseService<UserModel, User>, IUserService
    {
        public async Task<UserModel> GetAsync()
        {
            var user = Mapper.Map<UserModel>(await DbContext.User.FirstOrDefaultAsync());
            var addresses = Mapper.Map<ICollection<AddressModel>>(await DbContext.Address.ToListAsync());
            user.Vehicles = Mapper.Map<ObservableCollection<VehicleModel>>(await DbContext.Vehicle.AsNoTracking().Where(v=>!v.Deleted).ToListAsync());
            user.Address = addresses.FirstOrDefault(x => x.AddressId == user.AddressId);
            user.PlaceOfBusiness = addresses.FirstOrDefault(x => x.AddressId == user.PlaceOfBusinessId);

            return user;
        }
    }
}
