namespace DrobnyZivnostnik
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Database;
    using Database.Entities;
    using Models.Address;
    using Models.User;
    using Models.Vehicle;
    using Services;
    using Services.Interfaces;
    using Xamarin.Forms;

    /// <summary>
    /// Custom startup - made because of testing 
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Customs initialized method 
        /// </summary>
        public static void Initialized()
        {
            DependencyService.RegisterSingleton(CreateAutoMapper());
            DependencyService.Register<IAppDbContext, AppDbContext>();

            //Services
            DependencyService.Register<IAddressService, AddressService>();
            DependencyService.Register<IUserService, UserService>();
            DependencyService.Register<IVehicleService, VehicleService>();

#if DEBUG
            var task = Task.Run(async () => await PseudoSeedAsync()); // ONLY FOR DEBUG
            task.Wait();
#endif
        }

        /// <summary>
        /// Creates the automatic mapper.
        /// </summary>
        /// <returns></returns>
        private static IMapper CreateAutoMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressModel>();
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<Vehicle, VehicleModel>();
                cfg.CreateMap<VehicleModel, Vehicle>();
            }).CreateMapper();
        }

        /// <summary>
        /// Pseudoseed asynchronous.
        /// Adds data to db for testing
        /// </summary>
        /// <returns></returns>
        private static async Task PseudoSeedAsync()
        {
            var addressService = DependencyService.Resolve<IAddressService>();
            var userService = DependencyService.Resolve<IUserService>();
            var vehicleSerice = DependencyService.Resolve<IVehicleService>();

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
                IdentifyingNumber = "12132132",
                CreationDate = DateTime.Now,
                ImagePath = "sssssss"
            };

            await userService.AddAsync(user);
            
            var vehicle = new VehicleModel()
            {
                Name = "Škoda OCTAVIA II Combi",
                Deleted = false,
                FuelConsumption = 5.8,
                FuelType = "Diesel",
                NumberPlate = "4T5 4589",
                VehicleType = "O"
            };

            await vehicleSerice.AddAsync(vehicle);

            var vehicle2 = new VehicleModel()
            {
                Name = "Škoda FABIA III",
                Deleted = false,
                FuelConsumption = 8.8,
                FuelType = "Benzín",
                NumberPlate = "4T8 4565",
                VehicleType = "O"
            };

            await vehicleSerice.AddAsync(vehicle2);

            var vehicle3 = new VehicleModel()
            {
                Name = "Skázostroj",
                Deleted = false,
                FuelConsumption = 8.8,
                FuelType = "Benzín",
                NumberPlate = "AAA AAAA",
                VehicleType = "O"
            };

            await vehicleSerice.AddAsync(vehicle3);
        }
    }
}
