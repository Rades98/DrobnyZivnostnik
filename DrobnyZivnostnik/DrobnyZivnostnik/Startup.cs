namespace DrobnyZivnostnik
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Models.Address;
    using Models.User;
    using Services.Interfaces;
    using Xamarin.Forms;

    public static class Startup
    {
        public static void StartUp()
        {
            var task = Task.Run(async () => await PseudoSeedAsync());
            task.Wait();
        }

        private static async Task<ObservableCollection<UserListModel>> PseudoSeedAsync()
        {
            var addressService = DependencyService.Resolve<IAddressService>();

            var userService = DependencyService.Resolve<IUserService>();

            var address = new AddressModel()
            {
                City = "Čudnohor",
                Deleted = false,
                HouseNumber = "123",
                Street = "Nejaka ulice",
                ZipCode = "12345"
            };


            await addressService.AddAsync(address);

            var addresses = await addressService.GetAsync();

            var id = addresses.FirstOrDefault().AddressId;

            var user = new UserModel()
            {
                Name = "Tamten",
                Surname = "Teuton",
                Deleted = false,
                AddressId = id,
                IsActive = false,
                IdentifyingNumber = "12132132",
                CreationDate = DateTime.Now,
                ImagePath = "sssssss"
            };
            
            await userService.AddAsync(user);

            var result = await userService.GetUserListAsync();

            return new ObservableCollection<UserListModel>(result);
        }
    }
}
